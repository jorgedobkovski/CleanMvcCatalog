using CleanMvcCatalog.Domain.Account;
using CleanMvcCatalog.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanMvcCatalog.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;
        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        public IActionResult Logout()
        {
            _authenticate.Logout();
            return RedirectToAction("/Account/Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authenticate.Authenticate(model.Email, model.Password);
            if (result)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authenticate.Register(model.Email, model.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong.");
                return View(model);
            }
        }

    }
}

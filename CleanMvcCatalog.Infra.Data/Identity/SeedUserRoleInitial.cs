using CleanMvcCatalog.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedRoles()
        {
            if(!_roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                _roleManager.CreateAsync(role).Wait();
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                _roleManager.CreateAsync(role).Wait();
            }   
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@cleanmvc.com").Result == null) { 
                var user = new ApplicationUser
                {
                    UserName = "user@cleanmvc.com",
                    Email = "user@cleanmvc.com",
                    NormalizedEmail = "USER@CLEANMVC.COM",
                    NormalizedUserName = "USER@CLEANMVC.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                IdentityResult result = _userManager.CreateAsync(user, "User@123").Result;
                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
            }
            if (_userManager.FindByEmailAsync("admin@cleanmvc.com").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@cleanmvc.com",
                    Email = "admin@cleanmvc.com",
                    NormalizedEmail = "ADMIN@CLEANMVC.COM",
                    NormalizedUserName = "ADMIN@CLEANMVC.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                IdentityResult result = _userManager.CreateAsync(user, "Admin@123").Result;
                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}

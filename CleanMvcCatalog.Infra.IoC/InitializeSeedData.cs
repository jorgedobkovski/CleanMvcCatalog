using CleanMvcCatalog.Domain.Account;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Infra.IoC
{
    public static class InfrastructureDataInitializer
    {
        public static void InitializeSeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seedUserRoleInitial = scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();

                seedUserRoleInitial.SeedRoles();
                seedUserRoleInitial.SeedUsers();
            }
        }
    }
}

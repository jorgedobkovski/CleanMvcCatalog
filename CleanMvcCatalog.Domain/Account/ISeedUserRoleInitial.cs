using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Domain.Account
{
    public interface ISeedUserRoleInitial
    {
        void SeedUsers();
        void SeedRoles();
    }
}

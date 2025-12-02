using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
    }
}

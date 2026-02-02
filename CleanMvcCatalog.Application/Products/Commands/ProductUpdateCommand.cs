using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Application.Products.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}

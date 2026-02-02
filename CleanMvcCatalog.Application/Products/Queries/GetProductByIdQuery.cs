using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Application.Products.Queries
{
    public class GetProductByIdQuery
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}

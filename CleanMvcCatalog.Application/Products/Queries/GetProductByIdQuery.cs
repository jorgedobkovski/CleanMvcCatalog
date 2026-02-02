using CleanMvcCatalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}

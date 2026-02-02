using CleanMvcCatalog.Domain.Entities;
using MediatR;

namespace CleanMvcCatalog.Application.Products.Commands
{
    public class ProductCommand : IRequest<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
    }
}

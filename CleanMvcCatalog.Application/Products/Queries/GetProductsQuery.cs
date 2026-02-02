using CleanMvcCatalog.Domain.Entities;
using MediatR;

namespace CleanMvcCatalog.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}

using CleanMvcCatalog.Application.Products.Queries;
using CleanMvcCatalog.Domain.Entities;
using CleanMvcCatalog.Domain.Interfaces;
using MediatR;

namespace CleanMvcCatalog.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }
        public Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.GetProductsAsync();
        }
    }
}
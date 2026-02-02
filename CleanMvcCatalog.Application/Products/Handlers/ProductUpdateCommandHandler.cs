using CleanMvcCatalog.Application.Products.Commands;
using CleanMvcCatalog.Domain.Entities;
using CleanMvcCatalog.Domain.Interfaces;
using MediatR;

namespace CleanMvcCatalog.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetByIdAsync(request.Id).Result;

            if (product == null)
            {
                throw new ApplicationException($"The product with id {request.Id} was not found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}

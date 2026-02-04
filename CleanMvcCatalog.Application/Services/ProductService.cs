using AutoMapper;
using CleanMvcCatalog.Application.DTOs;
using CleanMvcCatalog.Application.Interfaces;
using CleanMvcCatalog.Application.Products.Commands;
using CleanMvcCatalog.Application.Products.Queries;
using CleanMvcCatalog.Domain.Entities;
using MediatR;

namespace CleanMvcCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery == null)
                throw new Exception("Products not found");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetById(int? id)
        {
            var productQuery = new GetProductByIdQuery(id.Value);

            if(productQuery == null)
                throw new Exception("Product not found");

            var result = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDto>(result);
        }
        
        public async Task Add(ProductDto productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDto productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}

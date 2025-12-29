using AutoMapper;
using CleanMvcCatalog.Application.DTOs;
using CleanMvcCatalog.Domain.Entities;

namespace CleanMvcCatalog.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}

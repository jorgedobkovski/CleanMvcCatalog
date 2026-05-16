using AutoMapper;
using CleanMvcCatalog.Application.DTOs;
using CleanMvcCatalog.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanMvcCatalog.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDto, ProductCreateCommand>();
            CreateMap<ProductDto, ProductUpdateCommand>();
        }
    }
}

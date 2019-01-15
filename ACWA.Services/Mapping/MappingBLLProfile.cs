using ACWA.Domain.Models;
using ACWA.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ACWA.Services.Mapping
{
    public class MappingBLLProfile : AutoMapper.Profile
    {
        public MappingBLLProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}

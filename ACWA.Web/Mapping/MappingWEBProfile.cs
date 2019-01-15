using ACWA.Services.DTO;
using ACWA.Web.ModelsView;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWA.Web.Mapping
{
    public class MappingWEBProfile : Profile
    {
        public MappingWEBProfile()
        {
            CreateMap<ProductDTO, ProductVM>().ReverseMap();
            CreateMap<CategoryDTO, CategoryVM>().ReverseMap();
           
        }
    }
}

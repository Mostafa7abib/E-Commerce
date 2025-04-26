using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Shared;

namespace Services.MappingProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            //Map Form Product To ProductResultDto
            CreateMap<Product, ProductResultDto>()
                .ForMember(D => D.BrandName, options =>options.MapFrom(S=> S.ProductBrand.Name))
                .ForMember(D=>D.TypeName,options=>options.MapFrom(S=>S.ProductType.Name))
                .ForMember(D=>D.PictureUrl,options=>options.MapFrom<PictureUrlResolver>());
            //Map Form ProductBrand To BrandResultDto
            CreateMap<ProductBrand, BrandResultDto>();
            //Map Form ProductType To TypeResultDto
            CreateMap<ProductType, TypeResultDto>();
        }
    }
}

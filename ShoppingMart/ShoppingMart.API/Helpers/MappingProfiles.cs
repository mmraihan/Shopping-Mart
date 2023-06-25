using AutoMapper;
using ShoppingMart.API.Dtos;
using ShoppingMart.Core.Entities;

namespace ShoppingMart.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(c => c.ProductBrand, o => o.MapFrom(o => o.ProductBrand.Name))
                .ForMember(c => c.ProductType, o => o.MapFrom(o => o.ProductType.Name))
                .ForMember(c => c.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}

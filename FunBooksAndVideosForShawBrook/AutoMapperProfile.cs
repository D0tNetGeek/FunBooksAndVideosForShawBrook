using AutoMapper;
using FunBooksAndVideosForShawBrook.Dto;
using FunBooksAndVideosForShawBrook.Entities;

namespace FunBooksAndVideosForShawBrook
{
    public class AutoMapperProfile : Profile
    {
        //Provide all the Mapping Configuration
        public AutoMapperProfile()
        {
            //Configuring Product and ProductDto
            CreateMap<OrderDto, PurchaseOrder>().ForMember(dest => dest.ItemLines, act => act.MapFrom(src => src.products));
            CreateMap<ProductDto, Product>().ForMember(dest => dest.ProductType, act => act.MapFrom(src => src.ProductType))
                                            .ForMember(dest => dest.MembershipType, act => act.Condition(src => src.MembershipType != null));

        }
    }
}
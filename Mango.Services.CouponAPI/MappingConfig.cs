using AutoMapper;
using Mango.Services.CouponAPI.Models.Dto;
using Mango.Services.CouponAPI.Models;

namespace Mango.Services.CouponAPI;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Coupon, CouponDto>()
            .ForMember(dest => dest.DiscountCode, opt => opt.MapFrom(src => src.CouponCode));
        CreateMap<CouponDto, Coupon>().ForMember(dest => dest.CouponCode, opt => opt.MapFrom(src => src.DiscountCode));
    }
}

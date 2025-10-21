using Riok.Mapperly.Abstractions;

namespace Mango.Services.CouponAPI.Models.Dto;
[Mapper]
public static partial class CouponDtoMapper
{
    [MapProperty(nameof(Coupon.CouponCode), nameof(CouponDto.DiscountCode))]
    public static partial CouponDto ToDto(this Coupon source);
}

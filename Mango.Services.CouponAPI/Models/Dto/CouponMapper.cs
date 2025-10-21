using Riok.Mapperly.Abstractions;

namespace Mango.Services.CouponAPI.Models.Dto;


[Mapper]
public static partial class CouponMapper
{
    [MapProperty(nameof(CouponDto.DiscountCode), nameof(Coupon.CouponCode))]
    public static partial Coupon ToCoupon(this CouponDto source);
}

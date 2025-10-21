using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;

using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponAPIController : ControllerBase
{
    private readonly AppDbContext _db;
    private ResponseDto _response;
    public CouponAPIController(AppDbContext db)
    {
        _db = db;
        _response = new ResponseDto();
    }

    [HttpGet]
    public ResponseDto Get()
    {
        try
        {
            IEnumerable<Coupon> objList = _db.Coupons.ToList();
            // Map each Coupon to CouponDto using the non-generic method
            var couponDtoList = objList.Select(c => CouponDtoMapper.ToDto(c)).ToList();
            _response.Result = couponDtoList;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpGet]
    [Route("{id:int}")]
    public ResponseDto Get(int id)
    {
        try
        {
            Coupon obj = _db.Coupons.First(u => u.CouponId == id);
            _response.Result = CouponDtoMapper.ToDto(obj);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpGet]
    [Route("GetByCode/{code}")]
    public ResponseDto GetByCode(string code)
    {
        try
        {
            Coupon obj = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
            _response.Result = CouponDtoMapper.ToDto(obj);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpPost]
    public ResponseDto Post([FromBody] CouponDto couponDto)
    {
        try
        {
            Coupon obj = CouponMapper.ToCoupon(couponDto);
            if(obj != null && ModelState.IsValid)
            {
                _db.Coupons.Add(obj);
            }
            _db.SaveChanges();

            _response.Result = CouponDtoMapper.ToDto(obj);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }


    [HttpPut]
    public ResponseDto put([FromBody] CouponDto couponDto)
    {
        try
        {
            Coupon obj = CouponMapper.ToCoupon(couponDto);
            _db.Coupons.Update(obj);
            _db.SaveChanges();

            _response.Result = CouponDtoMapper.ToDto(obj);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }

    [HttpDelete]
    public ResponseDto Delete(int id)
    {
        try
        {
            Coupon obj = _db.Coupons.First(u => u.CouponId == id);
            _db.Coupons.Remove(obj);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }
}

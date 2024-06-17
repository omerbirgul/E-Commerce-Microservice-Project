using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task<CreateCouponDto> CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<UpdateCouponDto> UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int couponId);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int couponId);
    }
}

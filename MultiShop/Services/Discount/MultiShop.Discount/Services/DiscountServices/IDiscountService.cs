using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int couponId);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int couponId);
        Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code);
        Task<int> GetDiscountRateAsync(string code);
    }
}

using MultiShop.Catalog.Dtos.CategorySlideDtos;

namespace MultiShop.Catalog.Services.CategorySlideServices
{
    public interface ICategorySlideService
    {
        Task<List<ResultCategorySlideDto>> GetAllCategorySlideAsync();
        Task <GetByIdCategorySlideDto> GetByIdCategorySlideAsync(string id);
        Task CreateCategorySlideAsync(CreateCategorySlideDto createCategorySlideDto);
        Task UpdateCategorySlideAsync(UpdateCategorySlideDto updateCategorySlideDto);
        Task DeleteCategorySlideAsync(string id);
        Task CategorySlideStatusToTrue(string id);
        Task CategorySlideStatusToFalse(string id);
    }
}

using MultiShop.DtoLayer.CatalogDtos.CategorySlideDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategorySlideServices
{
    public interface ICategorySlideService
    {
        Task<List<ResultCategorySlideDto>> GetAllCategorySlideAsync();
        Task CreateCategorySlideAsync(CreateCategorySlideDto createCategorySlideDto);
        Task UpdateCategorySlideAsync(UpdateCategorySlideDto updateCategorySlideDto);
        Task<GetByIdCategorySlideDto> GetCategorySlideByIdAsync(string id);
        Task DeleteCategorySlideAsync(string id);
    }
}

using MultiShop.DtoLayer.CatalogDtos.CategorySlideDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategorySlideServices
{
    public class CategorySlideService : ICategorySlideService
    {
        private readonly HttpClient _httpClient;

        public CategorySlideService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategorySlideAsync(CreateCategorySlideDto createCategorySlideDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategorySlideDto>("CategorySlide", createCategorySlideDto);
        }

        public async Task DeleteCategorySlideAsync(string id)
        {
            await _httpClient.DeleteAsync("CategorySlide/" + id);
        }

        public async Task<List<ResultCategorySlideDto>> GetAllCategorySlideAsync()
        {
            var responseMessage = await _httpClient.GetAsync("CategorySlide");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategorySlideDto>>();
            return values;
        }

        public async Task UpdateCategorySlideAsync(UpdateCategorySlideDto updateCategorySlideDto)
        {
            await _httpClient.PostAsJsonAsync<UpdateCategorySlideDto>("CategorySlide", updateCategorySlideDto);
        }
    }
}

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
            await _httpClient.PostAsJsonAsync<CreateCategorySlideDto>("CategorySlides", createCategorySlideDto);
        }

        public async Task DeleteCategorySlideAsync(string id)
        {
            await _httpClient.DeleteAsync("CategorySlides/" + id);
        }

        public async Task<List<ResultCategorySlideDto>> GetAllCategorySlideAsync()
        {
            var responseMessage = await _httpClient.GetAsync("CategorySlides");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategorySlideDto>>();
            return values;
        }

        public async Task<GetByIdCategorySlideDto> GetCategorySlideByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("CategorySlides/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategorySlideDto>();
            return value;
        }

        public async Task UpdateCategorySlideAsync(UpdateCategorySlideDto updateCategorySlideDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategorySlideDto>("CategorySlides", updateCategorySlideDto);
        }
    }
}

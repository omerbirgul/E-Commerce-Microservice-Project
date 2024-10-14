using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("categories/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("categories");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<GetByIdCategoryDto> GetCategoriesByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("categories/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
             await _httpClient.PostAsJsonAsync<UpdateCategoryDto>("categories" ,updateCategoryDto);
        }
    }
}

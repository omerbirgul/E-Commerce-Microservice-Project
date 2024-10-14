using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultBrandDto>> BrandListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Brands");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
            return values;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brands", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("Brands/" + id);
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Brands/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdBrandDto>();
            return value;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brands", updateBrandDto);
        }
    }
}

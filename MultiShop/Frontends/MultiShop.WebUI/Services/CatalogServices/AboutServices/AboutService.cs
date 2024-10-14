using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("Abouts", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("Abouts/" +  id);
        }

        public async Task<GetByIdAboutDto> GetAboutByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Abouts/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdAboutDto>();
            return value;
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Abouts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            return values;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("Abouts", updateAboutDto);
        }
    }
}

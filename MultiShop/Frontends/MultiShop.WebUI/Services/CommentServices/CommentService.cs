using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateUserCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync("comments", createCommentDto);
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            await _httpClient.DeleteAsync("comments/" + id);
        }

        public async Task<GetByIdCommentDto> GetCommentByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdCommentDto>(jsonData);
            return value;
        }

        public async Task<List<ResultCommentDto>> GetUserCommentByProductIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetCommentByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return values;
        }

        public async Task UpdateUserCommentAsync(UpdateCommentDto updateUserCommentDto)
        {
            await _httpClient.PutAsJsonAsync("comments", updateUserCommentDto);
        }

        public async Task<List<ResultCommentDto>> UserCommentListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }
    }
}

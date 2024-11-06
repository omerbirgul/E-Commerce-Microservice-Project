using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetAllUserAsync()
        {
            var responseMessage = await _httpClient.GetAsync("/api/users/GetAllUsers");
            var userListValues = await responseMessage.Content.ReadFromJsonAsync<List<ResultUserDto>>();
            if(userListValues != null)
            {
                return userListValues;
            }
            else
            {
                throw new Exception("User List cannot found");
            }
        }

        public async Task<UserDetailViewModel> GetUserInfoAsync()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuserinfo");
        }
    }
}

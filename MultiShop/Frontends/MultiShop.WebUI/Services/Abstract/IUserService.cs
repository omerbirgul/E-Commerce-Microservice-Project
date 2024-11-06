using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfoAsync();
        Task<List<ResultUserDto>> GetAllUserAsync(); 
    }
}

using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Services.IdentityUserServices
{
    public interface IIdentityUserService
    {
        Task<ResultUserDto> GetUserInfoAsync();
        Task<List<ApplicationUser>> GetAllUserAsync();
    }
}

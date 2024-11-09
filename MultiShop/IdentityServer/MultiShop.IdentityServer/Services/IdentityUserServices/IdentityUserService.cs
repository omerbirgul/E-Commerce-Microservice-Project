using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System;



namespace MultiShop.IdentityServer.Services.IdentityUserServices
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentityUserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<ApplicationUser>> GetAllUserAsync()
        {
            var userList = await _userManager.Users.ToListAsync();
            if (userList != null)
            {
                return userList;
            }
            else
            {
                throw new Exception("User list not found");
            }
        }


        public async Task<ResultUserDto> GetUserInfoAsync()
        {
            var userClaim =  _contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaim.Value);
            if (user != null)
            {
                return new ResultUserDto
                {
                    id = user.Id,
                    name = user.Name,
                    surname = user.Surname,
                    email = user.Email,
                    userName = user.UserName
                };
            }
            else
            {
                throw new Exception("User info not found");
            }
        }
    }
}

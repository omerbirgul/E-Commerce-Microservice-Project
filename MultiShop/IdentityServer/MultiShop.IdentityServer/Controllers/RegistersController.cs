﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.Username,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(values);
            if(result.Succeeded)
            {
            return Ok("User added succesfully");
            }
            else
            {
                return Ok("Error! Try again");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> UserList()
        {
            var userList = await _userService.GetAllUserAsync();
            return View(userList);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IUserService _userService;

        public MyOrderController(IOrderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfoAsync();
            var orderingValues = await _orderingService.GetOrderingByUserIdAsync(user.Id);
            return View(orderingValues);
        }
    }
}

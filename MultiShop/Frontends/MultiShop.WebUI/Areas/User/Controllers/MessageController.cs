using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfoAsync();
            var inboxValues = await _messageService.GetInboxMessagesAsync(user.Id);
            return View(inboxValues);
        }

        [HttpGet]
        public async Task<IActionResult> Sendbox()
        {
            var user = await _userService.GetUserInfoAsync();
            var sendboxValues = await _messageService.GetSendboxMessagesAsync(user.Id);
            return View(sendboxValues);
        }
    }
}

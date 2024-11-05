using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos.UserMessageDtos;
using MultiShop.Message.Services.MessageServices;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public MessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var messageValues = await _userMessageService.GetAllUserMessageAsync();
            return Ok(messageValues);
        }

        [HttpGet("GetAllInboxMessages/{id}")]
        public async Task<IActionResult> GetAllInboxMessages(string id)
        {
            var messageValues = await _userMessageService.GetAllInboxMessageAsync(id);
            return Ok(messageValues);
        }

        [HttpGet("GetAllSendboxMessages/{id}")]
        public async Task<IActionResult> GetAllSendboxMessages(string id)
        {
            var messageValues = await _userMessageService.GetAllSendboxMessageAsync(id);
            return Ok(messageValues);
        }

        [HttpGet("GetByIdMessage/{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var messageValue = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(messageValue);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("User message created successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Message deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Message updated successfully");
        }
    }
}

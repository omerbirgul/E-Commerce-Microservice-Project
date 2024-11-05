using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos.UserMessageDtos;

namespace MultiShop.Message.Services.MessageServices
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var messageValue = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(messageValue);
        }

        public async Task DeleteMessageAsync(int id)
        {
            var messageValue = await _messageContext.UserMessages.FindAsync(id);
            if (messageValue != null)
            {
                _messageContext.Remove(messageValue);
            }
        }

        public async Task<List<ResultInboxMessageDto>> GetAllInboxMessageAsync(string id)
        {
            var messageValues = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(messageValues);
        }

        public async Task<List<ResultSendboxMessageDto>> GetAllSendboxMessageAsync(string id)
        {
            var messageValues = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(messageValues);
        }

        public  async Task<List<ResultMessageDto>> GetAllUserMessageAsync()
        {
            var messageValues = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(messageValues);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var messageValue = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(messageValue);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var messageValue = _mapper.Map<UserMessage>(updateMessageDto);
            _messageContext.UserMessages.Update(messageValue);
        }
    }
}

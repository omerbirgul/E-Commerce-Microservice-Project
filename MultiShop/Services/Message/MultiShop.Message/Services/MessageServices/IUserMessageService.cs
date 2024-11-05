using MultiShop.Message.Dtos.UserMessageDtos;

namespace MultiShop.Message.Services.MessageServices
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllUserMessageAsync();
        Task<List<ResultInboxMessageDto>> GetAllInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetAllSendboxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}

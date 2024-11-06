using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Messages/GetAllInboxMessages/" + id);
            var inboxMessageValues = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            if(inboxMessageValues != null)
            {
                return inboxMessageValues;
            }
            else
            {
                throw new Exception("Inbox messages could not retrieved");
            }
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Messages/GetAllSendboxMessages/" + id);
            var sendboxMessageValues = await responseMessage.Content
                .ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            if(sendboxMessageValues != null)
            {
                return sendboxMessageValues;
            }
            else
            {
                throw new Exception("Senbox messages coult not retrieved");
            }
        }
    }
}

using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var basket = await GetBasket() ?? new BasketTotalDto(); //Sepet boşşa yeni bir sepet oluştur
            var existingItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);

            if(existingItem == null)
            {
                basket.BasketItems.Add(existingItem);
            }
            else
            {
                basket = new BasketTotalDto();
                basket.BasketItems.Add(basketItemDto);
            }

            await SaveBasket(basket);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var value = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return value;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var basket = await GetBasket();
            var deletedItem = basket.BasketItems.FirstOrDefault(x =>x.ProductId == productId);
            var result = basket.BasketItems.Remove(deletedItem);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync("baskets", basketTotalDto);
        }
    }
}

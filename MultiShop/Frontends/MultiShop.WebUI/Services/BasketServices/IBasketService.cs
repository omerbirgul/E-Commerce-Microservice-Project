using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(); // Sepetin tümünü getirir
        Task SaveBasket(BasketTotalDto basketTotalDto); // Sepeti kayıt eder
        Task AddBasketItem(BasketItemDto basketItemDto); // Sepetin içine yeni bir öğe ekler
        Task<bool> RemoveBasketItem(string productId); // Mevuctdaki öğeyi siler
        Task DeleteBasket(string userId); // Sepetin tamamını siler
    }
}

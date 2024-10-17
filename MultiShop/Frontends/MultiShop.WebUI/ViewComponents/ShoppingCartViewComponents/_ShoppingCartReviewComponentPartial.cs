using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartReviewComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartReviewComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BasketItemDto> basketItemDtos = new List<BasketItemDto>();
            var values = await _basketService.GetBasket();
            foreach (var item in values.BasketItems)
            {
                basketItemDtos.Add(item);
            }
            return View(basketItemDtos);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code, int discountRate, decimal discountedPrice)
        {
            var basketValues = await _basketService.GetBasket();
            var taxPrice = basketValues.TotalPrice * 10 / 100;
            var totalPriceWithTax = basketValues.TotalPrice + taxPrice;
            ViewBag.TotalPrice = basketValues.TotalPrice;
            ViewBag.TotalPriceWithTax = totalPriceWithTax;
            ViewBag.DiscountRate = discountRate;
            ViewBag.Code = code;
            ViewBag.TaxPrice = taxPrice;
            ViewBag.DiscountedPrice = discountedPrice;
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductID,
                Price = values.ProductPrice,
                ProductName = values.ProductName,
                ProductImageUrl = values.ProductImageURL,
                Quantity = 1
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}

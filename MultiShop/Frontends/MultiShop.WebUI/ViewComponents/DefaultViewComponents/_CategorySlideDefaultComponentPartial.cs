using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategorySlideDtos;
using MultiShop.WebUI.Services.CatalogServices.CategorySlideServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategorySlideDefaultComponentPartial : ViewComponent
    {
        private readonly ICategorySlideService _categorySlideService;

        public _CategorySlideDefaultComponentPartial(ICategorySlideService categorySlideService)
        {
            _categorySlideService = categorySlideService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _categorySlideService.GetAllCategorySlideAsync();
            return View(value);
        }
    }
}

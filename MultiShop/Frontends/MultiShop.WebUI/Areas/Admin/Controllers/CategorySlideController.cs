using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategorySlideDtos;
using MultiShop.WebUI.Services.CatalogServices.CategorySlideServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CategorySlide")]
    public class CategorySlideController : Controller
    {
        private readonly ICategorySlideService _categorySlideService;

        public CategorySlideController(ICategorySlideService categorySlideService)
        {
            _categorySlideService = categorySlideService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _categorySlideService.GetAllCategorySlideAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateCategorySlide")]
        public IActionResult CreateCategorySlide()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCategorySlide")]
        public async Task<IActionResult> CreateCategorySlide(CreateCategorySlideDto createCategorySlideDto)
        {
            await _categorySlideService.CreateCategorySlideAsync(createCategorySlideDto);
            return RedirectToAction("Index", "CategorySlide", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdateCategorySlide/{id}")]
        public async Task<IActionResult> UpdateCategorySlide(string id)
        {
            var value = await _categorySlideService.GetCategorySlideByIdAsync(id);
            var updateCategorySlideDto = new UpdateCategorySlideDto
            {
                CategorySlideId = value.CategorySlideId,
                CategoryTitle = value.CategoryTitle,
                CategoryImageUrl = value.CategoryImageUrl,
                Status = value.Status
            };
            return View(updateCategorySlideDto);
        }

        [HttpPost]
        [Route("UpdateCategorySlide/{id}")]
        public async Task<IActionResult> UpdateCategorySlide(UpdateCategorySlideDto updateCategorySlideDto)
        {
            await _categorySlideService.UpdateCategorySlideAsync(updateCategorySlideDto);
            return RedirectToAction("Index", "CategorySlide", new { area = "Admin" });

        }

        [Route("DeleteCategorySlide/{id}")]
        public async Task<IActionResult> DeleteCategorySlide(string id)
        {
            await _categorySlideService.DeleteCategorySlideAsync(id);
            return RedirectToAction("Index", "CategorySlide", new { area = "Admin" });

        }
    }
}

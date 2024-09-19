using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategorySlideDtos;
using MultiShop.Catalog.Services.CategorySlideServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorySlidesController : ControllerBase
    {
        private readonly ICategorySlideService _categorySlideService;

        public CategorySlidesController(ICategorySlideService categorySlideService)
        {
            _categorySlideService = categorySlideService;
        }

        [HttpGet]
        public async Task<IActionResult> CategorySlideList()
        {
            var values = await _categorySlideService.GetAllCategorySlideAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategorySlideById(string id)
        {
            var value = await _categorySlideService.GetByIdCategorySlideAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategorySlide(CreateCategorySlideDto createCategorySlideDto)
        {
            await _categorySlideService.CreateCategorySlideAsync(createCategorySlideDto);
            return Ok("Category Slide created successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategorySlie(UpdateCategorySlideDto updateCategorySlideDto)
        {
            await _categorySlideService.UpdateCategorySlideAsync(updateCategorySlideDto);
            return Ok("Category Slide updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorySlide(string id)
        {
            await _categorySlideService.DeleteCategorySlideAsync(id);
            return Ok("Category Slide deleted successfully");
        }
    }
}

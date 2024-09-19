using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategorySlideDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CategorySlide")]
    [AllowAnonymous]
    public class CategorySlideController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategorySlideController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7071/api/CategorySlides");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategorySlideDto>>(jsonData);
                return View(values);
            }
            return View();
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
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategorySlideDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:7071/api/CategorySlides", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CategorySlide", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateCategorySlide/{id}")]
        public async Task<IActionResult> UpdateCategorySlide(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7071/api/CategorySlides/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateCategorySlideDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateCategorySlide/{id}")]
        public async Task<IActionResult> UpdateCategorySlide(UpdateCategorySlideDto updateCategorySlideDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategorySlideDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:7071/api/CategorySlides", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CategorySlide", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteCategorySlide/{id}")]
        public async Task<IActionResult> DeleteCategorySlide(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:7071/api/CategorySlides/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CategorySlide", new { area = "Admin" });
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService,
            ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }

        private async Task<List<SelectListItem>> GetCategoryValues()
        {
            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            return categoryValues;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }

        [HttpGet]
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetAllProductsWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            
            ViewBag.CategoryValues = await GetCategoryValues();
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.CategoryValues = await GetCategoryValues();
            var values = await _productService.GetProductByIdAsync(id);
            var updateProductDto = new UpdateProductDto
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductDescription = values.ProductDescription,
                ProductImageURL = values.ProductImageURL,
                CategoryID = values.CategoryID
            };
            return View(updateProductDto);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _ProductDetailFeatureComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value = await _productService.GetProductByIdAsync(id);
            var updateProductDto = new UpdateProductDto
            {
                ProductID = value.ProductID,
                ProductName = value.ProductName,
                ProductDescription = value.ProductDescription,
                ProductPrice = value.ProductPrice,
                CategoryID = value.CategoryID,
                ProductImageURL = value.ProductImageURL
            };
            
            return View(updateProductDto);
        }
    }
}

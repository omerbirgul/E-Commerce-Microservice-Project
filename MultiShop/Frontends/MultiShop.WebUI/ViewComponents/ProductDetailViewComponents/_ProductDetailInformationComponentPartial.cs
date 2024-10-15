using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value = await _productDetailService.GetByProductIdProductDetailAsync(id);
            var updateProducDetailtDto = new UpdateProductDetailDto
            {
                ProductDescription = value.ProductDescription,
                ProductID = value.ProductID,
                ProductDetailID = value.ProductDetailID,
                ProductInfo = value.ProductInfo
            };
            return View(updateProducDetailtDto);
        }
    }
}

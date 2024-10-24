﻿using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<GetByIdProductDto> GetProductByIdAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductsWithCategoryByCategoryIdAsync(string id);
    }
}

﻿using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
        Task CreateContactAsync(CreateContactDto createContactDto);
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAdressCommandHandler _createAdressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;

        public AdressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAdressCommandHandler createAdressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAdressCommandHandler = createAdressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAdressCommand command)
        {
            await _createAdressCommandHandler.Handle(command);
            return Ok("Address info created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _removeAdressCommandHandler.Handle(new RemoveAdressCommand(id));
            return Ok("Address info deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAdressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Address info updated successfully");
        }


    }
}

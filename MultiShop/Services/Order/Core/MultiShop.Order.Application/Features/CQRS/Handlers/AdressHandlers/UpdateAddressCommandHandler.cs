using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAdressCommand updateAdressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAdressCommand.AddressId);
            values.Detail = updateAdressCommand.Detail;
            values.City = updateAdressCommand.City;
            values.District = updateAdressCommand.District;
            values.UserId = updateAdressCommand.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}

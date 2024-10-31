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
    public class CreateAdressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAdressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAdressCommand createAdressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAdressCommand.City,
                AddressDetail1 = createAdressCommand.AddressDetail1,
                AddressDetail2 = createAdressCommand.AddressDetail2,
                UserId = createAdressCommand.UserId,
                Country = createAdressCommand.Country,
                District = createAdressCommand.District,
                Email = createAdressCommand.Email,
                FirstName = createAdressCommand.FirstName,
                LastName = createAdressCommand.LastName,
                Phone = createAdressCommand.Phone,
                PostalCode = createAdressCommand.PostalCode
            });
        }
    }
}

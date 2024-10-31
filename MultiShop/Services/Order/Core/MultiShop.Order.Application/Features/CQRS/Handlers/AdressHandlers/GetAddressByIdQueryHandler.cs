using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAdressByIdQueryResult> Handle(GetAdressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAdressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.AddressDetail1,
                District = values.District,
                UserId = values.UserId,
            };
        }
    }
}

using CarBook.Application.Features.Mediator.Queries.RentalPriceQueries;
using CarBook.Application.Features.Mediator.Results.RentalPriceResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentalPriceHandlers
{
    public class GetRentalPriceQueryHandler : IRequestHandler<GetRentalPriceQuery, List<GetRentalPriceQueryResult>>
    {
        private readonly IRentalPriceRepository _repository;

        public GetRentalPriceQueryHandler(IRentalPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentalPriceQueryResult>> Handle(GetRentalPriceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetRentalPrices();
            return values.Select(x => new GetRentalPriceQueryResult
            {
                Brand = x.Car.Brand.Name,
                ImageUrl = x.Car.ImageUrl,
                Model = x.Car.Model,
                Price = x.Price,
                CarId = x.Car.Id,
                Id = x.Id,
                PricingType = x.PricingType.Name,
                PricingTypeId = x.PricingTypeId
               
            }).ToList();
        }
    }
}

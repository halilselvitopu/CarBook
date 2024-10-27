using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                BrandId = x.BrandId,               
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Luggage = x.Luggage,
                Mileage = x.Mileage,
                Model = x.Model,
                Seat = x.Seat,
                DetailImageUrl = x.DetailImageUrl,
                Fuel = x.Fuel,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}

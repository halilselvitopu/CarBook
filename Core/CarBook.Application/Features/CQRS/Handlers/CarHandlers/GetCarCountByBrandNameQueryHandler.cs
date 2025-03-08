using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarCountByBrandNameQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarCountByBrandNameQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<GetCarCountByBrandNameQueryResult>> Handle()
        {
            var carCountByBrand = await _carRepository.GetCarCountByBrandName();

            return carCountByBrand
                .Select(x => new GetCarCountByBrandNameQueryResult
                {
                    BrandName = x.Key,
                    CarCount = x.Value
                })
                .ToList();
        }
    }
}
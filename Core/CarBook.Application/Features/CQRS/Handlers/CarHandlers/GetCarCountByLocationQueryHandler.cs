using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{

    public class GetCarCountByLocationQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarCountByLocationQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<GetCarCountByLocationQueryResult>> Handle()
        {
            var carCountByLocation = await _carRepository.GetCarCountByLocation();

            return carCountByLocation
                .Select(x => new GetCarCountByLocationQueryResult
                {
                    LocationName = x.Key,
                    CarCount = x.Value
                })
                .ToList();
        }
    }
}

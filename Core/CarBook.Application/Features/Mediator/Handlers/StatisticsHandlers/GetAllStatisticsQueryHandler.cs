using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAllStatisticsQueryHandler : IRequestHandler<GetAllStatisticsQuery, GetAllStatisticsQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetAllStatisticsQueryHandler(IStatisticsRepository statisticRepository)
        {
            _statisticsRepository = statisticRepository;
        }

        public async Task<GetAllStatisticsQueryResult> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
        {
            var carCount = await _statisticsRepository.GetCarCountAsync();
            var locationCount = await _statisticsRepository.GetLocationCountAsync();
            var authorCount = await _statisticsRepository.GetAuthorCountAsync();
            var blogCount = await _statisticsRepository.GetBlogCountAsync();
            var brandCount = await _statisticsRepository.GetBrandCountAsync();
            var averageDailyCarRentalPrice = await _statisticsRepository.GetAvgDailyCarRentalPriceAsync();
            var averageWeeklyCarRentalPrice = await _statisticsRepository.GetAvgWeeklyCarRentalPriceAsync();
            var averageMonthlyCarRentalPrice = await _statisticsRepository.GetAvgMonthlyCarRentalPriceAsync();
            var carCountByAutoTransmission = await _statisticsRepository.GetCarCountByAutoTransmissionAsync();
            var brandNameByMostCar = await _statisticsRepository.GetBrandByMostCarAsync();
            var blogByMostComment = await _statisticsRepository.GetBlogByMostCommentAsync();
            var carCountUnder1000Km = await _statisticsRepository.GetCarCountUnder1000KmAsync();
            var countOfGasolineOrDieselCars = await _statisticsRepository.GetCountOfGasolineOrDieselCarsAsync();
            var electricCarCount = await _statisticsRepository.GetElectricCarCountAsync();
            var cheapestCar = await _statisticsRepository.GetCheapestCarAsync();
            var mostExpensiveCar = await _statisticsRepository.GetMostExpensiveCarAsync();
            return new GetAllStatisticsQueryResult
            {
                CarCount = carCount,
                LocationCount = locationCount,
                AuthorCount = authorCount,
                BlogCount = blogCount,
                BrandCount = brandCount,
                AverageDailyCarRentalPrice = averageDailyCarRentalPrice,
                AverageWeeklyCarRentalPrice = averageWeeklyCarRentalPrice,
                AverageMonthlyCarRentalPrice = averageMonthlyCarRentalPrice,
                CarCountByAutoTransmission = carCountByAutoTransmission,
                BrandNameByMostCar = brandNameByMostCar,
                BlogByMostComment = blogByMostComment,
                CarCountUnder1000Km = carCountUnder1000Km,
                CountOfGasolineOrDieselCars = countOfGasolineOrDieselCars,
                ElectricCarCount = electricCarCount,
                CheapestCar = cheapestCar,
                MostExpensiveCar = mostExpensiveCar


            };
        }
    }
}

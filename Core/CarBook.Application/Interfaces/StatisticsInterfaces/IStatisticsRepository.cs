using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetCarCountAsync();
        Task<int> GetLocationCount();
        Task<int> GetAuthorCount();
        Task<int> GetBlogCount();
        Task<int> GetBrandCount();
        Task<decimal> AvgDailyCarRentalPrice();
        Task<decimal> AvgWeeklyCarRentalPrice();
        Task<decimal> AvgMonthlyCarRentalPrice();
        Task<int> GetCarCountByAutoTransmission();
        Task<string> GetBrandByMostCar();
        Task<string> GetBlogByMostComment();
        Task<int> GetCarsUnder1000Km();
        Task<int> GetCountOfGasolineOrDieselCars();
        Task<int> GetElectricCarCount();
        Task<string> GetCheapestCar();
        Task<int> GetMostExpensiveCar();

    }
}

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
        Task<int> GetLocationCountAsync();
        Task<int> GetAuthorCountAsync();
        Task<int> GetBlogCountAsync();
        Task<int> GetBrandCountAsync();
        Task<decimal> GetAvgDailyCarRentalPriceAsync();
        Task<decimal> GetAvgWeeklyCarRentalPriceAsync();
        Task<decimal> GetAvgMonthlyCarRentalPriceAsync();
        Task<int> GetCarCountByAutoTransmissionAsync();
        Task<string> GetBrandByMostCarAsync();
        Task<string> GetBlogByMostCommentAsync();
        Task<int> GetCarCountUnder1000KmAsync();
        Task<int> GetCountOfGasolineOrDieselCarsAsync();
        Task<int> GetElectricCarCountAsync();
        Task<string> GetCheapestCarAsync();
        Task<string> GetMostExpensiveCarAsync();

    }
}

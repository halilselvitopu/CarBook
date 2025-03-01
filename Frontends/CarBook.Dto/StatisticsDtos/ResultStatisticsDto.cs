using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int AuthorCount { get; set; }
        public decimal AverageDailyCarRentalPrice { get; set; }
        public decimal AverageMonthlyCarRentalPrice { get; set; }
        public decimal AverageWeeklyCarRentalPrice { get; set; }
        public int BlogCount { get; set; }
        public string BrandNameByMostCar { get; set; }
        public int BrandCount { get; set; }
        public int CarCountByAutoTransmission { get; set; }
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int CarCountUnder1000Km { get; set; }
        public string BlogByMostComment { get; set; }
        public int CountOfGasolineOrDieselCars { get; set; }
        public int ElectricCarCount { get; set; }
        public string CheapestCar { get; set; }
        public string MostExpensiveCar { get; set; }
    }
}

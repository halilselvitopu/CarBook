using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<decimal> AvgDailyCarRentalPrice()
        {
            int id =  _context.PricingTypes.Where(y => y.Name == "Günlük").Select(z => z.Id).FirstOrDefault();
            return await _context.RentalPrices.Where(w => w.PricingTypeId == id).AverageAsync(x => x.Price);
        }

        public async Task<decimal> AvgMonthlyCarRentalPrice()
        {
            int id = _context.PricingTypes.Where(y => y.Name == "Aylık").Select(z => z.Id).FirstOrDefault();
            return await _context.RentalPrices.Where(w => w.PricingTypeId == id).AverageAsync(x => x.Price);
        }

        public async Task<decimal> AvgWeeklyCarRentalPrice()
        {
            int id = _context.PricingTypes.Where(y => y.Name == "Haftalık").Select(z => z.Id).FirstOrDefault();
            return await _context.RentalPrices.Where(w => w.PricingTypeId == id).AverageAsync(x => x.Price);
        }

        public async Task<int> GetBlogCount()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<int> GetAuthorCount()
        {
            return await _context.Authors.CountAsync();
        }

        public Task<string> GetBlogByMostComment()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBrandByMostCar()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetBrandCount()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<int> GetCarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetCarCountByAutoTransmission()
        {
           return await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
        }

        public async Task<int> GetCarsUnder1000Km()
        {
            return await _context.Cars.Where(x => x.Mileage < 1000).CountAsync();
        }

        public Task<string> GetCheapestCar()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountOfGasolineOrDieselCars()
        {
            return await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
        }

        public async Task<int> GetElectricCarCount()
        {
           return await _context.Cars.Where(x => x.Fuel == "Elektrik").CountAsync();
        }

        public async Task<int> GetLocationCount()
        {
            return await _context.Locations.CountAsync();
        }

        public Task<int> GetMostExpensiveCar()
        {
            throw new NotImplementedException();
        }
    }
}

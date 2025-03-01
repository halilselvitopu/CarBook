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

        public async Task<decimal> GetAvgDailyCarRentalPriceAsync()
        {
            int id =  _context.PricingTypes.Where(y => y.Name == "Günlük").Select(z => z.Id).FirstOrDefault();
            return await _context.RentalPrices.Where(w => w.PricingTypeId == id).AverageAsync(x => x.Price);
        }

        public async Task<decimal> GetAvgMonthlyCarRentalPriceAsync()
        {
            int id = _context.PricingTypes.Where(y => y.Name == "Aylık").Select(z => z.Id).FirstOrDefault();
            return await _context.RentalPrices.Where(w => w.PricingTypeId == id).AverageAsync(x => x.Price);
        }

        public async Task<decimal> GetAvgWeeklyCarRentalPriceAsync()
        {
            int id = _context.PricingTypes.Where(y => y.Name == "Haftalık").Select(z => z.Id).FirstOrDefault();
            return await _context.RentalPrices.Where(w => w.PricingTypeId == id).AverageAsync(x => x.Price);
        }

        public async Task<int> GetBlogCountAsync()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<int> GetAuthorCountAsync()
        {
            return await _context.Authors.CountAsync();
        }

        public Task<string> GetBlogByMostCommentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBrandByMostCarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetBrandCountAsync()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<int> GetCarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetCarCountByAutoTransmissionAsync()
        {
           return await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
        }

        public async Task<int> GetCarCountUnder1000KmAsync()
        {
            return await _context.Cars.Where(x => x.Mileage < 1000).CountAsync();
        }

        public Task<string> GetCheapestCarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCountOfGasolineOrDieselCarsAsync()
        {
            return await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
        }

        public async Task<int> GetElectricCarCountAsync()
        {
           return await _context.Cars.Where(x => x.Fuel == "Elektrik").CountAsync();
        }

        public async Task<int> GetLocationCountAsync()
        {
            return await _context.Locations.CountAsync();
        }

        public async Task<string> GetMostExpensiveCarAsync()
        {
            throw new  NotImplementedException();
        }
    }
}

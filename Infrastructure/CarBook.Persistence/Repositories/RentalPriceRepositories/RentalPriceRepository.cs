using CarBook.Application.Features.Mediator.Results.RentalPriceResults;
using CarBook.Application.Interfaces.RentalPriceInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.RentalPriceRepositories
{
    public class RentalPriceRepository : IRentalPriceRepository
    {
        private readonly CarBookContext _context;

        public RentalPriceRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<List<RentalPrice>> GetRentalPrices()
        {
            var values = _context.RentalPrices.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.PricingType).Where(p => p.PricingTypeId == 2).ToListAsync();
            return values;
        }

        public async Task<List<GetRentalPriceWithTimePeriodQueryResult>> GetRentalPricesWithTimePeriod()
        {
            var query = from RentalPrice in _context.RentalPrices
                        join cars in _context.Cars on RentalPrice.CarId equals cars.Id
                        join brands in _context.Brands on cars.BrandId equals brands.Id
                        group RentalPrice by new
                        {
                            BrandAndModel = brands.Name + " " + cars.Model
                        } into grouped
                        select new GetRentalPriceWithTimePeriodQueryResult
                        {
                            BrandAndModel = grouped.Key.BrandAndModel,
                            DailyPrice = grouped.Where(x => x.PricingTypeId == 1).Sum(x => x.Price),
                            WeeklyPrice = grouped.Where(x => x.PricingTypeId == 2).Sum(x => x.Price),
                            MonthlyPrice = grouped.Where(x => x.PricingTypeId == 3).Sum(x => x.Price),
                            ImageUrl = grouped.Select(x => x.Car.ImageUrl).FirstOrDefault(),
                            CarId = grouped.Select(x => x.CarId).FirstOrDefault()
                        };

            var values = query.ToList();
            return values;
        }

    }
}


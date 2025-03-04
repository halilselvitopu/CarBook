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
            var values = await _context.Database.SqlQueryRaw<GetRentalPriceWithTimePeriodQueryResult>("select Brands.Name+' '+Model as Model,ImageUrl,[2] as 'DailyPrice',[3] as 'WeeklyPrice',[5] as 'MonthlyPrice' from\r\n(select Brands.Name+' '+Model as Model,Pricings.PricingId,Price,ImageUrl from RentalPrices inner join Cars on Cars.CarId=RentalPrices.CarId inner join Brands on Cars.BrandId=Brands.BrandId inner join Pricings on Pricings.PricingId=RentalPrices.PricingId) as Source_table\r\nPivot(\r\nSum(Price) For PricingId in ([2],[3],[5])\r\n) as Pivot_table").ToListAsync();
            return values;
        }
    }
}


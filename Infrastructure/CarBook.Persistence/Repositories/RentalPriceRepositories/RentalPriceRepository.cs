using CarBook.Application.Interfaces.CarPricingInterfaces;
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
            var values = _context.RentalPrices.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.PricingType).Where(p => p.PricingTypeId == 3).ToListAsync();
            return values;
        }
    }
}

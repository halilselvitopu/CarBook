using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task ChangeCarFeatureStatusToAvailable(int id)
        {
            var values = await _context.CarFeatures.Where(x => x.Id == id).FirstOrDefaultAsync();
             values.IsAvailable = true;
            await _context.SaveChangesAsync();
        }

        public async Task ChangeCarFeatureStatusToNotAvailable(int id)
        {
            var values = await _context.CarFeatures.Where(x => x.Id == id).FirstOrDefaultAsync();
            values.IsAvailable = false;
            await _context.SaveChangesAsync();
        }

        public async Task CreateCarFeatureByCar(CarFeature carFeature)
        {
            await _context.CarFeatures.AddAsync(carFeature);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarFeature>> GetCarFeatureByCarId(int id)
        {
            var values = await _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarId == id).ToListAsync();
            return values;
        }
    }
}

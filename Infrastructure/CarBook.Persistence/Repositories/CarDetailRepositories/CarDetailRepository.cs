using CarBook.Application.Interfaces.CarDetailInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDetailRepositories
{
    public class CarDetailRepository : ICarDetailRepository
    {
        private readonly CarBookContext _context;

        public CarDetailRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<CarDetail> GetCarDetail(int carId)
        {
            return await _context.CarDetails.Where(x => x.CarId == carId).FirstOrDefaultAsync();
        }
    }
}

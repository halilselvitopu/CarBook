﻿using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarListWithBrands()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }


        public Task<List<Car>> GetLast5CarsWithBrands()
        {
            return _context.Cars.Include(x =>x.Brand).OrderByDescending(x => x.Id).Take(5).ToListAsync();
        }
    }
}

﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarListWithBrands();
        Task<List<Car>> GetLast5CarsWithBrands();
        Task<Dictionary<string, int>> GetCarCountByBrandName();
        Task<Dictionary<string, int>> GetCarCountByLocation();


    }
}

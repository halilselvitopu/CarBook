﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeatureByCarId(int id);
        Task ChangeCarFeatureStatusToNotAvailable(int id);
        Task ChangeCarFeatureStatusToAvailable(int id);
        Task CreateCarFeatureByCar(CarFeature carFeature);
    }
}

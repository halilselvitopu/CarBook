﻿using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>>Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                BrandId = x.BrandId,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Luggage = x.Luggage,
                Mileage = x.Mileage,
                Model = x.Model,
                Seat = x.Seat,
                DetailImageUrl = x.DetailImageUrl,
                Fuel = x.Fuel,
                Transmission = x.Transmission
                
                
            }).ToList();
        }
    }
}

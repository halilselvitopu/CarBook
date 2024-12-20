﻿using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandId = value.BrandId,
                Id = value.Id,
                ImageUrl = value.ImageUrl,
                Luggage = value.Luggage,
                Mileage = value.Mileage,
                Model = value.Model,
                Seat = value.Seat,
                DetailImageUrl = value.DetailImageUrl,
                Fuel = value.Fuel,
                Transmission = value.Transmission
            };
        }
    }
}

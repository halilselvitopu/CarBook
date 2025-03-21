﻿using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BrandId = command.BrandId,
                DetailImageUrl = command.DetailImageUrl,
                ImageUrl = command.ImageUrl,
                Mileage = command.Mileage,
                Luggage = command.Luggage,
                Model = command.Model,
                Seat = command.Seat,
                Fuel = command.Fuel,
                Transmission = command.Transmission

                
            });
        }
    }
}

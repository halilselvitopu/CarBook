using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            value.BrandId = command.BrandId;
            value.DetailImageUrl = command.DetailImageUrl;
            value.Model = command.Model;
            value.Mileage = command.Mileage;
            value.ImageUrl = command.ImageUrl;
            value.Luggage = command.Luggage;
            value.Seat  = command.Seat;
            value.Fuel = command.Fuel;
            value.Transmission = command.Transmission;

            await _repository.UpdateAsync(value);
        }
    }
}

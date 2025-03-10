﻿using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureStatusToAvailableCommandHandler : IRequestHandler<UpdateCarFeatureStatusToAvailableCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureStatusToAvailableCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeatureStatusToAvailableCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.ChangeCarFeatureStatusToAvailable(request.Id);
        }
    }
}

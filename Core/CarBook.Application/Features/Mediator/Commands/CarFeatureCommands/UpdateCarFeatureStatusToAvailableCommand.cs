using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureStatusToAvailableCommand : IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureStatusToAvailableCommand(int id)
        {
            Id = id;
        }
    }
}

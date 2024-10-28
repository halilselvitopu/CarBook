using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FooterContactCommands
{
    public class RemoveFooterContactCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFooterContactCommand(int id)
        {
            Id = id;
        }
    }
}

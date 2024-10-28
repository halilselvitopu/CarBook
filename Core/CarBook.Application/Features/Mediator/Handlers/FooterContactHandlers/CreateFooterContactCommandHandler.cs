using CarBook.Application.Features.Mediator.Commands.FooterContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterContactHandlers
{
    public class CreateFooterContactCommandHandler : IRequestHandler<CreateFooterContactCommand>
    {
        private readonly IRepository<FooterContact> _repository;

        public CreateFooterContactCommandHandler(IRepository<FooterContact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterContactCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterContact
            {
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            });
        }
    }
}

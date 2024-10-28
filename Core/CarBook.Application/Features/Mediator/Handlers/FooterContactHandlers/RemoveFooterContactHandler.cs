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
    public class RemoveFooterContactHandler : IRequestHandler<RemoveFooterContactCommand>
    {
        private readonly IRepository<FooterContact> _repository;

        public RemoveFooterContactHandler(IRepository<FooterContact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterContactCommand request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.Id);
           await _repository.RemoveAsync(value);
        }
    }
}

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
    public class UpdateFooterContactHandler : IRequestHandler<UpdateFooterContactCommand>
    {
        private readonly IRepository<FooterContact> _repository;

        public UpdateFooterContactHandler(IRepository<FooterContact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.PhoneNumber = request.PhoneNumber;
            value.Address = request.Address;
            value.Description = request.Description;
            value.Email = request.Email;
            await _repository.UpdateAsync(value);

            }
        }
}

using CarBook.Application.Features.Mediator.Queries.FooterContactQueries;
using CarBook.Application.Features.Mediator.Results.FooterContactResults;
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
    public class GetFooterContactByIdQueryHandler : IRequestHandler<GetFooterContactByIdQuery, GetFooterContactByIdQueryResult>
    {
        private readonly IRepository<FooterContact> _repository;

        public GetFooterContactByIdQueryHandler(IRepository<FooterContact> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterContactByIdQueryResult> Handle(GetFooterContactByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterContactByIdQueryResult
            {
                Id = value.Id,
                PhoneNumber = value.PhoneNumber,
                Address = value.Address,
                Description = value.Description,
                Email = value.Email,
            };
        }
    }
}

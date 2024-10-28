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
    public class GetFooterContactQueryHandler : IRequestHandler<GetFooterContactQuery, List<GetFooterContactQueryResult>>
    {
        private readonly IRepository<FooterContact> _repository;

        public GetFooterContactQueryHandler(IRepository<FooterContact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterContactQueryResult>> Handle(GetFooterContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterContactQueryResult
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
            }).ToList();
        }
    }
}

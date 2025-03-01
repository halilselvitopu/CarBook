﻿using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.Pricing;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<PricingType> _repository;

        public GetPricingByIdQueryHandler(IRepository<PricingType> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
            };
        }
    }
}

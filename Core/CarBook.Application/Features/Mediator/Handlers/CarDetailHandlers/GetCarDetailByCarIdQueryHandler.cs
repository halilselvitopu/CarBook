using CarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using CarBook.Application.Features.Mediator.Results.CarDetailResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDetailInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDetailHandlers
{
    public class GetCarDetailByCarIdQueryHandler : IRequestHandler<GetCarDetailByCarIdQuery, GetCarDetailQueryResult>
    {
        private readonly ICarDetailRepository _repository;

        public GetCarDetailByCarIdQueryHandler(ICarDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDetailQueryResult> Handle(GetCarDetailByCarIdQuery request, CancellationToken cancellationToken)
        {
           var values = await _repository.GetCarDetail(request.CarId);
            return new GetCarDetailQueryResult
            {
                Id = values.Id,
                Details = values.Details,
                CarId = values.CarId,

            };
        }
    }
}

using CarBook.Application.Features.Mediator.Queries.RentalPriceQueries;
using CarBook.Application.Features.Mediator.Results.RentalPriceResults;
using CarBook.Application.Interfaces.RentalPriceInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentalPriceHandlers
{
    public class GetRentalPriceWithTimePeriodQueryHandler : IRequestHandler<GetRentalPriceWithTimePeriodQuery, List<GetRentalPriceWithTimePeriodQueryResult>>
    {
        private readonly IRentalPriceRepository _repository;

        public GetRentalPriceWithTimePeriodQueryHandler(IRentalPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentalPriceWithTimePeriodQueryResult>> Handle(GetRentalPriceWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetRentalPricesWithTimePeriod();
            var result = values.Select(x => new GetRentalPriceWithTimePeriodQueryResult
            {
                BrandAndModel = x.BrandAndModel,
                DailyPrice = x.DailyPrice,
                WeeklyPrice = x.WeeklyPrice,
                MonthlyPrice = x.MonthlyPrice,
                ImageUrl = x.ImageUrl,
                CarId = x.CarId
            }).ToList();

            return result;
        }
    }
}

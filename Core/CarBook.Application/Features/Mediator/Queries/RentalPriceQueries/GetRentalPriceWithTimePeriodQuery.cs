using CarBook.Application.Features.Mediator.Results.RentalPriceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.RentalPriceQueries
{
    public class GetRentalPriceWithTimePeriodQuery : IRequest<List<GetRentalPriceWithTimePeriodQueryResult>>
    {
    }
}

using CarBook.Application.Features.Mediator.Queries.RentalPriceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalPricesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalPricesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentalPriceList()
        {
            return Ok(await _mediator.Send(new GetRentalPriceQuery()));
        }

        [HttpGet("GetRentalPricesWithTimePeriod")]
        public async Task<IActionResult> GetRentalPriceListWithTimePeriod()
        {
            return Ok(await _mediator.Send(new GetRentalPriceWithTimePeriodQuery()));
        }
    }
}

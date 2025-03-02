using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int locationId, bool IsAvailable)
        {
            GetRentACarQuery query = new GetRentACarQuery()
            {
                LocationId = locationId,
                IsAvailable = IsAvailable

            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

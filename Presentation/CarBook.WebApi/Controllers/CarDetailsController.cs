using CarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCarDetailByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarDetailByCarIdQuery(id));
            return Ok(values);
        }
    }
}

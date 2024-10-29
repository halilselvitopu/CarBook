using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            return Ok(await _mediator.Send(new GetLocationQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(RemoveLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi.");
        }
    }
}

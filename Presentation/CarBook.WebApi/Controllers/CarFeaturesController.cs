using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
            var value = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeCarFeatureStatusToAvailable(int id)
        {
            await _mediator.Send(new UpdateCarFeatureStatusToAvailableCommand(id));
            return Ok("Başarıyla Güncellendi.");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeCarFeatureStatusToNotAvailable(int id)
        {
            await _mediator.Send(new UpdateCarFeatureStatusToNotAvailableCommand(id));
            return Ok("Başarıyla Güncellendi.");
        }
    }
}

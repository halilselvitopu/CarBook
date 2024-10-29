using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.Pricing;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            return Ok(await _mediator.Send(new GetPricingQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePricing(RemovePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }
    }
}

using CarBook.Application.Features.Mediator.Commands.FooterContactCommands;
using CarBook.Application.Features.Mediator.Queries.FooterContactQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> FooterContactList()
        {
            return Ok(await _mediator.Send(new GetFooterContactQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FooterContactList(int id)
        {
            var value = await _mediator.Send(new GetFooterContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterContact(CreateFooterContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi.");
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveFooterContact(RemoveFooterContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterContact(UpdateFooterContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }
    }
}

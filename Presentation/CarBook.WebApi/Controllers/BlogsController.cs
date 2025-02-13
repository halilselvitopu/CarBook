﻿using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            return Ok(await _mediator.Send(new GetBlogQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi");
        }

        [HttpGet("GetLast3BlogsWithAuthorList")]
        public async Task<IActionResult> GetLast3BlogsWithAuthorList()
        {
            return Ok(await _mediator.Send(new GetLast3BlogsWithAuthorsQuery()));
        }

        [HttpGet("GetAllBlogsWithAuthors")]
        public async Task<IActionResult> GetAllBlogsWithAuthors()
        {
            return Ok(await _mediator.Send(new GetBlogWithAuthorQuery()));
        }

        [HttpGet("GetAuthorByBlogId")]
        public async Task<IActionResult> GetAuthorByBlogId(int id)
        {
            return Ok(await _mediator.Send(new GetBlogByAuthorIdQuery(id)));
        }
    }
}

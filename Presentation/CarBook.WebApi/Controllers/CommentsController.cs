﻿using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _commentRepository.GetAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveComment(int id)
        {
            var value = await _commentRepository.GetByIdAsync(id);
            await _commentRepository.RemoveAsync(value);
            return Ok("Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            await _commentRepository.UpdateAsync(comment);
            return Ok("Başarıyla Güncellendi.");
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var value = await _commentRepository.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsByBlog(int id)
        {
            var value = await _commentRepository.GetCommentsByBlogIdAsync(id);
            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCountByBlog(int id)
        {
            var value = await _commentRepository.GetCommentCountByBlog(id);
            return Ok(value);
        }

    }
}

using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _commentRepository.GetAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            await _commentRepository.CreateAsync(comment);
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
    }
}

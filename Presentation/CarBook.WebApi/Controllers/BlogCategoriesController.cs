using CarBook.Application.Features.CQRS.Commands.BlogCategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.BlogCategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.BlogCategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.BlogCategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private readonly CreateBlogCategoryCommandHandler _createBlogCategoryHandler;
        private readonly UpdateBlogCategoryCommandHandler _updateBlogCategoryQueryHandler;
        private readonly GetBlogCategoryByIdQueryHandler _getBlogCategoryByIdQueryHandler;
        private readonly GetBlogCategoryQueryHandler _getBlogCategoryQueryHandler;
        private readonly RemoveBlogCategoryCommandHandler _removeBlogCategoryHandler;

        public BlogCategoriesController(CreateBlogCategoryCommandHandler createBlogCategoryHandler, UpdateBlogCategoryCommandHandler updateBlogCategoryQueryHandler, GetBlogCategoryByIdQueryHandler getBlogCategoryByIdQueryHandler, GetBlogCategoryQueryHandler getBlogCategoryQueryHandler, RemoveBlogCategoryCommandHandler removeBlogCategoryHandler)
        {
            _createBlogCategoryHandler = createBlogCategoryHandler;
            _updateBlogCategoryQueryHandler = updateBlogCategoryQueryHandler;
            _getBlogCategoryByIdQueryHandler = getBlogCategoryByIdQueryHandler;
            _getBlogCategoryQueryHandler = getBlogCategoryQueryHandler;
            _removeBlogCategoryHandler = removeBlogCategoryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BlogCategoryList()
        {
            return Ok(await _getBlogCategoryQueryHandler.Handle());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogCategoryById(int id)
        {
            return Ok(await _getBlogCategoryByIdQueryHandler.Handle(new GetBlogCategoryByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> C(CreateBlogCategoryCommand command)
        {
            await _createBlogCategoryHandler.Handle(command);
            return Ok("Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlogCategory(int id)
        {
            await _removeBlogCategoryHandler.Handle(new RemoveBlogCategoryCommand(id));
            return Ok("Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryCommand command)
        {
            await _updateBlogCategoryQueryHandler.Handle(command);
            return Ok("Başarıyla Güncellendi");
        }


    }
}

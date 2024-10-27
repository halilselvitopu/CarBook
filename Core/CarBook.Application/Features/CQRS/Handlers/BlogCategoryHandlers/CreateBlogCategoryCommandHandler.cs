using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BlogCategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogCategoryHandlers
{
    public class CreateBlogCategoryCommandHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public CreateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
          
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCategoryCommand command)
        {
            await _repository.CreateAsync(new BlogCategory
            {
                Name = command.Name
            });
        }
    }
}

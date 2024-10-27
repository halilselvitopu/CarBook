using CarBook.Application.Features.CQRS.Results.BlogCategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogCategoryHandlers
{
    public class GetBlogCategoryQueryHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetBlogCategoryQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogCategoryQueryResult
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();

        }
    }
}

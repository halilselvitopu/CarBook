using CarBook.Application.Features.CQRS.Queries.BlogCategoryQueries;
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
    public class GetBlogCategoryByIdQueryHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetBlogCategoryByIdQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCategoryByIdQueryResult> Handle(GetBlogCategoryByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetBlogCategoryByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name

            };
        }
    }
}

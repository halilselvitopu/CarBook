using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithAuthorQueryHandler : IRequestHandler<GetBlogWithAuthorQuery, List<GetBlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogWithAuthorQueryResult>> Handle(GetBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogsWithAuthors();
            return values.Select(x => new GetBlogWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorFirstName = x.Author.FirstName,
                AuthorLastName = x.Author.LastName,
                BlogCategoryName = x.BlogCategory.Name,
                CreatedTime = x.CreatedTime,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                BlogCategoryId = x.BlogCategory.Id,
                Content = x.Content,
                AuthorDescription = x.Author.Description

            }).ToList();
        }
    }
}

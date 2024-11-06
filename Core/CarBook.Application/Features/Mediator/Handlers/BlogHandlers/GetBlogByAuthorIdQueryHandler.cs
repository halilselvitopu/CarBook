using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAuthorByBlogId(request.Id);
            return values.Select(x => new GetBlogByAuthorIdQueryResult
            {
                AuthorFirstName = x.Author.FirstName,
                AuthorLastName = x.Author.LastName,
                AuthorDescription = x.Author.Description,
                AuthorId = x.Author.Id,
                Id = x.Id,
                AuthorImageUrl = x.Author.ImageUrl,

            }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogByAuthorIdQueryResult
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorImageUrl { get; set; }
    }
}

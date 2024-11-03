using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogWithAuthorQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
    }
}

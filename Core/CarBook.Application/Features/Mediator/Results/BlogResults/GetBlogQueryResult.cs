using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public int BlogCategoryId { get; set; }
    }
}

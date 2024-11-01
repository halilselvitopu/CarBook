using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public int BlogCategoryId { get; set; }
    }
}

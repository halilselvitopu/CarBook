using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudWithBlogCommand : IRequest
    {
        public string Title { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}

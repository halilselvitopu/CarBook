using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public string Email { get; set; }
    }
}

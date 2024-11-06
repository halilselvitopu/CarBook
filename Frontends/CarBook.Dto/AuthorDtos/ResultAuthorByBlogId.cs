using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AuthorDtos
{
    public class ResultAuthorByBlogId
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorImageUrl { get; set; }
    }
}

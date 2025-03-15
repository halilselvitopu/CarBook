using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ReviewDtos
{
    public class ResultReviewByCarIdDto
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Image { get; set; }
        public string Comment { get; set; }
        public string RatingValue { get; set; }
        public DateTime CommentDate { get; set; }
        public int CarId { get; set; }
    }
}

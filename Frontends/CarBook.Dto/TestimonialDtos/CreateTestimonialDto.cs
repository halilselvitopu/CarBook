﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.BlogCategoryResults
{
    public class GetBlogCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

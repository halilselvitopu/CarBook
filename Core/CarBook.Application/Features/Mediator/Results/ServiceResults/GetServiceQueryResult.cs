﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.ServiceResults
{
    public class GetServiceQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}

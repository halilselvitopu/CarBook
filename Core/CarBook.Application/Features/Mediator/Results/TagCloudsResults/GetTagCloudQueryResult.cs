﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.TagClouds
{
    public class GetTagCloudQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }

    }
}

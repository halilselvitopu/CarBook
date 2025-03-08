using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarResults
{
    public class GetCarCountByLocationQueryResult
    {
        public int CarCount { get; set; }
        public string LocationName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarDetailResults
{
    public class GetCarDetailQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Details { get; set; }

    }
}

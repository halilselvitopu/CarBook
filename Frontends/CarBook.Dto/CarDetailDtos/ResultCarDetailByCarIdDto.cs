using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDetailDtos
{
    public class ResultCarDetailByCarIdDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public int CarId { get; set; }
    }
}

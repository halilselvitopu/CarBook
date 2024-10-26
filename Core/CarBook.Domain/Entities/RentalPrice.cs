using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentalPrice
    {
        public int Id { get; set; }
        public RentalType RentalType { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public decimal Price { get; set; }

    }
}

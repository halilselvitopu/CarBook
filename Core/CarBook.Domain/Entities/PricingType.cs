using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class PricingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RentalPrice> RentalPrices { get; set; }
    }
}

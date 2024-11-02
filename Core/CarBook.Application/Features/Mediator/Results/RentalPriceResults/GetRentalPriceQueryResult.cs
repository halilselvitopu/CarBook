using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.RentalPriceResults
{
    public class GetRentalPriceQueryResult
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public string Model { get; set; }
        public int PricingTypeId { get; set; }
        public string PricingType { get; set; }
        public decimal Price { get; set; }
    }
}

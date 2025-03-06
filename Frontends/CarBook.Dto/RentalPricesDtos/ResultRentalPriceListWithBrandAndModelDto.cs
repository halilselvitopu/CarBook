using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.RentalPricesDtos
{
    public class ResultRentalPriceListWithBrandAndModelDto
    {

        public string BrandAndModel { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        public string ImageUrl { get; set; }
        public int CarId { get; set; }
    }

}

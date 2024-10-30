using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDtos
{
    public class ResultCarWithBrandDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public int Mileage { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string DetailImageUrl { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
    }
}

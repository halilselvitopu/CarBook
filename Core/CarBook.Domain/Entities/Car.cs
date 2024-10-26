using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public int Mileage { get; set; }
        public TransmissionType Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
        public string DetailImageUrl { get; set; }
        public List<CarFeature> CarFeature { get; set; }
        public List<CarDetail> CarDetail { get; set; }
        public List<RentalPrice> RentalPrice { get; set; }
    }
}

using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/Statistics");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(content);
                ViewBag.AverageDailyCarRentalPrice = values.AverageDailyCarRentalPrice;
                ViewBag.AverageMonthlyCarRentalPrice = values.AverageMonthlyCarRentalPrice;
                ViewBag.AverageWeeklyCarRentalPrice = values.AverageWeeklyCarRentalPrice;
                ViewBag.BlogCount = values.BlogCount;
                ViewBag.BrandNameByMostCar = values.BrandNameByMostCar;
                ViewBag.BrandCount = values.BrandCount;
                ViewBag.AuthorCount = values.AuthorCount;
                ViewBag.CarCount = values.CarCount;
                ViewBag.CarCountByAutoTransmission = values.CarCountByAutoTransmission;
                ViewBag.LocationCount = values.LocationCount;
                ViewBag.CarCountUnder1000Km = values.CarCountUnder1000Km;
                ViewBag.BlogByMostComment = values.BlogByMostComment;
                ViewBag.CountOfGasolineOrDieselCars = values.CountOfGasolineOrDieselCars;
                ViewBag.ElectricCarCount = values.ElectricCarCount;
                ViewBag.CheapestCar = values.CheapestCar;
                ViewBag.MostExpensiveCar = values.MostExpensiveCar;
            }

            return View();
        }
    }
}

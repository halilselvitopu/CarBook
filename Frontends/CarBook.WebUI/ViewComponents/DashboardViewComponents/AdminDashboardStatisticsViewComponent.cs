using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class AdminDashboardStatisticsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardStatisticsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/Statistics");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(content);
                ViewBag.AverageDailyCarRentalPrice = values.AverageDailyCarRentalPrice;
                ViewBag.BrandCount = values.BrandCount;            
                ViewBag.CarCount = values.CarCount;
                ViewBag.LocationCount = values.LocationCount;

            }

            return View();
        }
    }
}

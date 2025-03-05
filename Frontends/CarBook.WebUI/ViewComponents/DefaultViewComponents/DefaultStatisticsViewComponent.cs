using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultStatisticsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DefaultStatisticsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/Statistics");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(content);
                ViewBag.CarCount = values.CarCount;
                ViewBag.LocationCount = values.LocationCount;
                ViewBag.BrandCount = values.BrandCount;
                ViewBag.ElectricCarCount = values.ElectricCarCount;

            }
            return View();
        }
    }
}

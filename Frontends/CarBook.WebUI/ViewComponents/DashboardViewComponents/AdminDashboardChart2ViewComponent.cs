using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class AdminDashboardChart2ViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardChart2ViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/Cars/GetCarCountByBrandName");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarCountByBrandNameDto>>(content);
                return View(values);
            }

            return View();
        }
    }
}

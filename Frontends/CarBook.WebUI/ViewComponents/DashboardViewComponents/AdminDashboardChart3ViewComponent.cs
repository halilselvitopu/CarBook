using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardViewComponents
{
    public class AdminDashboardChart3ViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminDashboardChart3ViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/Cars/GetCarCountByLocation");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarCountByLocationDto>>(content);
                return View(values);
            }

            return View();
        }
    }
}

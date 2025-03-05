using CarBook.Dto.RentalPricesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class RentalPriceController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public RentalPriceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/RentalPrices/GetRentalPricesWithTimePeriod");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRentalPriceListWithBrandAndModelDto>>(content);
                return View(values);
            }

            return View();
        }



    }
}

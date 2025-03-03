using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var locationId = TempData["locationId"];
            if (locationId == null || !int.TryParse(locationId.ToString(), out int parsedLocationId))
            {
                
                return BadRequest("Location ID geçersiz veya eksik.");
            }

            id = parsedLocationId; 
            ViewBag.locationId = id;

            
            ViewBag.bookPickDate = TempData["bookPickDate"]?.ToString();
            ViewBag.bookOffDate = TempData["bookOffDate"]?.ToString();
            ViewBag.timePick = TempData["timePick"]?.ToString();
            ViewBag.timeOff = TempData["timeOff"]?.ToString();

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7127/api/RentACar?locationId={id}&IsAvailable=true");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RentACarFilterDto>>(content);
                return View(values);
            }

            return View();
        }
    }
}

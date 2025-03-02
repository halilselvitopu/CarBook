using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/Locations");

            var content = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(content);
            List<SelectListItem> locations = (from x in values
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            ViewBag.locations = locations;
            return View();

        }

        [HttpPost]
        public IActionResult Index(string bookPickDate, string bookOffDate, string timePick, string timeOff, int locationId)
        {
            // Breakpoint koyarak locationId'nin değerini kontrol et
            Console.WriteLine($"Gelen locationId: {locationId}"); // Konsola yazdır (veya logla)

            TempData["bookPickDate"] = bookPickDate;
            TempData["bookOffDate"] = bookOffDate;
            TempData["timePick"] = timePick;
            TempData["timeOff"] = timeOff;
            TempData["locationId"] = locationId; // Burada locationId'nin atanmasını kontrol et
            return RedirectToAction("Index", "RentACarList");
        }
    }
}

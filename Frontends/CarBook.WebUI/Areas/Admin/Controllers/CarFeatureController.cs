using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CarFeature")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/CarFeatures/GetCarFeatureByCarId/" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(content);
                return View(values);
            }

            return View();
        }

        [Route("Index/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.IsAvailable)
                {  
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7127/api/CarFeatures/ChangeCarFeatureStatusToAvailable?id=" + item.Id);


                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7127/api/CarFeatures/ChangeCarFeatureStatusToNotAvailable?id=" + item.Id);
                }

            }
            return RedirectToAction("Index", "AdminCar");

        }
    }
}

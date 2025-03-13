using CarBook.Dto.CarDetailDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponent
{
    public class CarDetailDescriptionViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarDetailDescriptionViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/CarDetails/GetCarDetailByCarId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarDetailByCarIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

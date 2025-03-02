using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class RentACarFilterViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarFilterViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7127/api/Locations");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<IEnumerable<ResultLocationDto>>(jsonData);
            IEnumerable<SelectListItem> locations = (from x in values
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.Id.ToString()
                                                     });
            ViewBag.locations = locations;
            return View();
        }
    }
}

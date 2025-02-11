using CarBook.Dto.FooterContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FooterContact")]
    public class FooterContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/FooterContacts");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterContactDto>>(content);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateFooterContact")]
        public async Task<IActionResult> CreateFooterContact()
        {

            return View();

        }

        [HttpPost]
        [Route("CreateFooterContact")]
        public async Task<IActionResult> CreateFooterContact(CreateFooterContactDto createFooterContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFooterContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7127/api/FooterContacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterContact", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveFooterContact/{id}")]
        public async Task<IActionResult> RemoveFooterContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7127/api/FooterContacts?id= + {id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterContact", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateFooterContact/{id}")]
        public async Task<IActionResult> UpdateFooterContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/FooterContacts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateFooterContactDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateFooterContact/{id}")]
        public async Task<IActionResult> UpdateFooterContact(UpdateFooterContactDto updateFooterContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFooterContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7127/api/FooterContacts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterContact", new { area = "Admin" });
            }
            return View();
        }
    }
}

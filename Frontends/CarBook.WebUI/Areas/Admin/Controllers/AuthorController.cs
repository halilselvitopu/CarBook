﻿using CarBook.Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/Author")]
    public class AuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7127/api/Authors");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(content);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor()
        {

            return View();

        }

        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAuthorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7127/api/Authors", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Author", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7127/api/Authors?id= + {id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Author", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/Authors/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAuthorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7127/api/Authors/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Author", new { area = "Admin" });
            }
            return View();
        }
    }
}

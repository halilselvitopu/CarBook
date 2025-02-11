using CarBook.Dto.BlogCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    
        [Area("Admin")]
        [Route("Admin/BlogCategory")]
        public class BlogCategoryController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public BlogCategoryController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }


            [Route("Index")]
            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7127/api/BlogCategories");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultBlogCategoryDto>>(content);
                    return View(values);
                }

                return View();
            }

            [HttpGet]
            [Route("CreateBlogCategory")]
            public async Task<IActionResult> CreateBlogCategory()
            {

                return View();

            }

            [HttpPost]
            [Route("CreateBlogCategory")]
            public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto createBlogCategoryDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBlogCategoryDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7127/api/BlogCategories", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "BlogCategory", new { area = "Admin" });
                }
                return View();
            }

            [Route("RemoveBlogCategory/{id}")]
            public async Task<IActionResult> RemoveBlogCategory(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"https://localhost:7127/api/BlogCategories?id= + {id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "BlogCategory", new { area = "Admin" });
                }
                return View();
            }

            [HttpGet]
            [Route("UpdateBlogCategory/{id}")]
            public async Task<IActionResult> UpdateBlogCategory(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:7127/api/BlogCategories/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<UpdateBlogCategoryDto>(jsonData);
                    return View(value);
                }
                return View();
            }

            [HttpPost]
            [Route("UpdateBlogCategory/{id}")]
            public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto updateBlogCategoryDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBlogCategoryDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7127/api/BlogCategories/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "BlogCategory", new { area = "Admin" });
                }
                return View();
            }
        }
}

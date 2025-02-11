using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7127/api/Comments/GetCommentsByBlog?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(content);
                return View(values);
            }

            return View();
        }
    }
}

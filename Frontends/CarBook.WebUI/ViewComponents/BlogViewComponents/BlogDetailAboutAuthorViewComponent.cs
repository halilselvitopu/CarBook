using CarBook.Dto.AuthorDtos;
using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class BlogDetailAboutAuthorViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailAboutAuthorViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/Blogs/GetAuthorByBlogId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAuthorByBlogId>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

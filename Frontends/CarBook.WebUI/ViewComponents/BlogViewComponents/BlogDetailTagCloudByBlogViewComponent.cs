using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class BlogDetailTagCloudByBlogViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailTagCloudByBlogViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/TagClouds/GetTagCloudByBlogId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTagCloudByBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

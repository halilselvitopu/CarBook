﻿using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class BlogDetailsMainViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailsMainViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7127/api/Blogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBlogByIdDto>(jsonData);
                var responseMessage2 = await client.GetAsync($"https://localhost:7127/api/Comments/GetCommentCountByBlog?id=" + id);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.CommentCount = jsonData2;
                return View(values);
            }
            return View();
        }
    }
}

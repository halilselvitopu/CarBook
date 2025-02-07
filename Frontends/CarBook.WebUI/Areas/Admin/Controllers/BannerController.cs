using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")] 
    public class BannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

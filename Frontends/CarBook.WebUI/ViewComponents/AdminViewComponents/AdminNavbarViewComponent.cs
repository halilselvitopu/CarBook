using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminViewComponents
{
    public class AdminNavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

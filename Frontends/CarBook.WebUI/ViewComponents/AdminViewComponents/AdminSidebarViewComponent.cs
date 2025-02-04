using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminViewComponents
{
    public class AdminSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminViewComponents
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

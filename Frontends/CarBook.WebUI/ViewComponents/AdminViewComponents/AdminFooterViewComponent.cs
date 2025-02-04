using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminViewComponents
{
    public class AdminFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

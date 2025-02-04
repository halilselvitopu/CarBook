using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AdminViewComponents
{
    public class AdminScriptsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}

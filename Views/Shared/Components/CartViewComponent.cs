using Microsoft.AspNetCore.Mvc;

namespace ЛР_1.Views.Shared.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

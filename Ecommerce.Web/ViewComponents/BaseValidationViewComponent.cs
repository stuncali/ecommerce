using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Ecommerce.Web.ViewComponents
{
    public class BaseValidationViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke(BaseViewModel model)
        {
            return View(model);
        }
    }
}

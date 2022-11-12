using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class HomeController : Controller
    {
       
        public HomeController()
        {       
        }

        public IActionResult Index()
        {
            return View();
        }
       
    }
}

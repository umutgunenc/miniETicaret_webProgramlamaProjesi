using Microsoft.AspNetCore.Mvc;

namespace miniETicaret.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

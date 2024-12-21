using Microsoft.AspNetCore.Mvc;

namespace miniETicaret.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

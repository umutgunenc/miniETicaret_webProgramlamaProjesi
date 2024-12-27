using Microsoft.AspNetCore.Mvc;

namespace miniETicaret.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

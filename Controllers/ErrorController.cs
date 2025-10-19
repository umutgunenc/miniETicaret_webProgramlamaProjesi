using Microsoft.AspNetCore.Mvc;

namespace miniETicaret.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("/Error/Status")]
        public IActionResult Status(int? code)
        {
            if (code.HasValue)
            {
                if (code == 404)
                {
                    ViewData["ErrorMessage"] = "Sayfa bulunamadı.";
                }
                else if (code == 500)
                {
                    ViewData["ErrorMessage"] = "Sunucu hatası oluştu.";
                }
                else
                {
                    ViewData["ErrorMessage"] = $"Bir hata oluştu. Hata kodu: {code}";
                }
            }
            return View();
        }
    }
}

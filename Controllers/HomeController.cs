using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniETicaret.Data;
using miniETicaret.Models.ViewModel.Home;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly eTicaretDBContext _eTicaretDBContext;

        public HomeController(eTicaretDBContext eTicaretDBContext)
        {
            _eTicaretDBContext = eTicaretDBContext;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new(_eTicaretDBContext);
            model.Products = await model.GetProductsAsync();
            return View(model);
        }
    }
}

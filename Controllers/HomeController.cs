using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
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

        //public async Task<IActionResult> Index()
        //{
        //    IndexViewModel model = new(_eTicaretDBContext);
        //    model.Products = await model.GetProductsAsync();
        //    return View(model);
        //}
        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new(_eTicaretDBContext);
            model.Products = await _eTicaretDBContext.Products
                .Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Despriction = p.Despriction,
                    Price = p.Price,
                    StockCount = p.StockCount, // Stok miktarı alınıyor
            ImgUrl = p.ImgUrl
                })
                .ToListAsync();

            return View(model);
        }

    }
}

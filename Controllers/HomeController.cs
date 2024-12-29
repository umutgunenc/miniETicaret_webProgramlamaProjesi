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

        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new(_eTicaretDBContext);
            model.Products = await model.GetProductsAsync(); //ıd,name,desp,price,stockCount,imgurl
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return RedirectToAction("Index");
            }

            var products = await _eTicaretDBContext.Products
                .Where(p => p.Name.ToLower().Contains(searchQuery.ToLower()) && p.IsActive)
                .Select(p => new Models.ViewModel.Products.ProductViewModel
	            {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockCount = p.StockCount,
                    ImgUrl = p.ImgUrl
                })
                .ToListAsync();


            return View("SearchResults", products);
        }



    }
}

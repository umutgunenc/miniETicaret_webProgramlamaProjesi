using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using miniETicaret.Data;
using miniETicaret.Models.ViewModel.Products;
using System.Threading.Tasks;

namespace miniETicaret.Controllers
{
    public class ProductsController : Controller
    {
        private readonly eTicaretDBContext _eTicaretDBContext;

        public ProductsController(eTicaretDBContext eTicaretDBContext)
        {
            _eTicaretDBContext = eTicaretDBContext;
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            ProductsDetailViewModel model = new(_eTicaretDBContext);

            model = await model.GetProductsDetailViewModelAsync(id);

            return View(model);
        }
    }
}

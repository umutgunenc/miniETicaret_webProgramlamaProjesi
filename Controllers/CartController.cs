using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Products;
using miniETicaret.Validators.Cart;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Controllers
{
    public class CartController : Controller
    {
        private readonly eTicaretDBContext _eTicaretDBContext;
        private readonly UserManager<AppUser> _userManager;
        public CartController(eTicaretDBContext eTicaretDBContext, UserManager<AppUser> userManager)
        {
            _eTicaretDBContext = eTicaretDBContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddCart(ProductsDetailViewModel model)
        {
            CartValidor validator = new();
            ValidationResult result = validator.Validate(model);


            AppUser user = await _userManager.GetUserAsync(User);
            Cart userCart = await _eTicaretDBContext.Carts
                .Where(c => c.CustomerId == user.Id && c.ProductId == model.Id)
                .FirstOrDefaultAsync();

            int quantityForTotalStock = model.Quantity;

            if (userCart != null)
                model.Quantity += userCart.Quantity;


            if (!result.IsValid)
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.ErrorMessage);
                }

                ProductsDetailViewModel returnModel = new(_eTicaretDBContext);
                returnModel = await returnModel.GetProductsDetailViewModelAsync(model.Id);

                return View("~/Views/Products/Detail.cshtml", returnModel);
            }

            Product product = await _eTicaretDBContext.Products
                .FirstOrDefaultAsync(p => p.Id == model.Id);
            product.StockCount -= quantityForTotalStock;
            _eTicaretDBContext.Update(product);

            await _eTicaretDBContext.SaveChangesAsync();

            if (userCart != null)
            {
                userCart.Quantity = model.Quantity;
                _eTicaretDBContext.Update(userCart);
            }
            else
            {
                Cart cart = new();
                cart.ProductId = product.Id;
                cart.Quantity = model.Quantity;
                cart.CustomerId = user.Id;
                await _eTicaretDBContext.Carts.AddAsync(cart);
            }

            await _eTicaretDBContext.SaveChangesAsync();


            TempData["ProductAddedToCart"] = "Ürün sepetinize başarıyla eklendi.";

            return RedirectToAction("Detail", "Products", new { id = model.Id });

        }
    }
}

using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Products;
using miniETicaret.Validators.Cart;
using System;
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

            AppUser user = await _userManager.GetUserAsync(User);
            Cart userCartItem = await _eTicaretDBContext.Carts
                .Where(c => c.CustomerId == user.Id && c.ProductId == model.Id)
                .FirstOrDefaultAsync();

            //int quantityForTotalStock = model.Quantity;

            //if (userCartItem != null)
            //    model.Quantity += userCartItem.Quantity;


            //product.StockCount -= quantityForTotalStock;
            //_eTicaretDBContext.Update(product);

            //await _eTicaretDBContext.SaveChangesAsync();

            if (userCartItem != null)
            {
                userCartItem.Quantity += model.Quantity;
                _eTicaretDBContext.Update(userCartItem);
            }
            else
            {
                Cart cart = new();
                Product product = await _eTicaretDBContext.Products
                     .FirstOrDefaultAsync(p => p.Id == model.Id);
                cart.ProductId = product.Id;
                cart.Quantity = model.Quantity;
                cart.CustomerId = user.Id;
                await _eTicaretDBContext.Carts.AddAsync(cart);
            }

            await _eTicaretDBContext.SaveChangesAsync();


            TempData["ProductAddedToCart"] = "Ürün sepetinize başarıyla eklendi.";

            return RedirectToAction("Detail", "Products", new { id = model.Id });

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            AppUser user = await _userManager.GetUserAsync(User);

            Cart userCartItem = await _eTicaretDBContext.Carts
                .Where(c => c.CustomerId == user.Id && c.ProductId == productId)
                .FirstOrDefaultAsync();
            try
            {
                if (userCartItem != null)
                {
                    _eTicaretDBContext.Carts.Remove(userCartItem);
                    await _eTicaretDBContext.SaveChangesAsync();
                    return Json(new { success = true });
                }
                else
                    return Json(new { success = false, message = "Bu ürün sepetinizde bulunmamaktadır." });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }


        }


        [HttpPost]
        public async Task<IActionResult> UpdateCart(int productId, int newQuantity)
        {
            AppUser user = await _userManager.GetUserAsync(User);

            Cart cartItem = await _eTicaretDBContext.Carts
                .Include(c => c.Product)
                .FirstOrDefaultAsync(c => c.CustomerId == user.Id && c.ProductId == productId);

            if (cartItem == null)
                return Json(new { success = false, message = "Sepet ürünü bulunamadı." });

            int maxAvailableQuantity = cartItem.Product.StockCount + cartItem.Quantity;
            if (newQuantity > maxAvailableQuantity)
            {
                newQuantity = maxAvailableQuantity;
                return Json(new
                {
                    success = false,
                    message = $"Stok yetersiz. Mevcut stok: {cartItem.Product.StockCount}. Alabileceğiniz maksimum miktar: {newQuantity}.",
                    newQuantity = newQuantity
                });
            }

            int oldQuantity = cartItem.Quantity;
            cartItem.Quantity = newQuantity;

            // Stok miktarını güncelle
            cartItem.Product.StockCount -= newQuantity - oldQuantity;

            // Eğer stok 0'ın altına düşerse, kullanıcıya uyarı gönder
            if (cartItem.Product.StockCount < 0)
            {
                cartItem.Product.StockCount = 0; // Stok sayısını 0'a çekiyoruz
                return Json(new
                {
                    success = false,
                    message = "Stok tükenmiş. Lütfen daha küçük bir miktar seçin.",
                    newStock = cartItem.Product.StockCount
                });
            }

            // Veritabanında güncellemeleri kaydet
            _eTicaretDBContext.Update(cartItem);
            _eTicaretDBContext.Update(cartItem.Product);
            await _eTicaretDBContext.SaveChangesAsync();

            return Json(new { success = true, message = "Sepet güncellendi.", newStock = cartItem.Product.StockCount });
        }


    }
}

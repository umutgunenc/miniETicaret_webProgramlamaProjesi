using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Products;
using miniETicaret.Validators.Cart;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> ConfirmCart([FromBody] List<Cart> selectedItems)
        {
            if (selectedItems == null || !selectedItems.Any())
                return Json(new { success = false, message = "Sepetinizde herhangi bir ürün yok." });

            AppUser customer = await _userManager.GetUserAsync(User);
            decimal totalPrice = 0;


            foreach (var item in selectedItems)
            {

                Product product = await _eTicaretDBContext.Products
                    .Where(p => p.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null)
                    return Json(new { success = false, message = "Ürün bulunamadı." });

                if (product.StockCount < item.Quantity)
                    return Json(new { success = false, message = $"Sepetinizde Bulunan {product.Name} İsimli Ürünün Stoğu Yetersiz.\n\nEn Fazla {product.StockCount} Adet Satın Alabilirsiniz." });

                totalPrice += item.Quantity * product.Price;
            }

            Order order = new()
            {
                CustomerId = customer.Id,
                OrderTime = DateTime.Now,
                TotalPrice = totalPrice,
                Despriction = $"{customer.Name} {customer.SurName} -- {DateTime.Now.ToString("dd:MM:yyyy")}"
            };

            await _eTicaretDBContext.Orders.AddAsync(order);
            await _eTicaretDBContext.SaveChangesAsync();

            foreach (var item in selectedItems)
            {
                Product product = await _eTicaretDBContext.Products
                    .Where(p => p.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                Cart customerCart = await _eTicaretDBContext.Carts
                    .Where(c => c.ProductId == product.Id && c.CustomerId == customer.Id)
                    .FirstOrDefaultAsync();

                _eTicaretDBContext.Carts.Remove(customerCart);
                await _eTicaretDBContext.SaveChangesAsync();

                product.StockCount -= item.Quantity;
                _eTicaretDBContext.Update(product);
                await _eTicaretDBContext.SaveChangesAsync();


                ProductOrder productOrder = new()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    SellerId = product.SellerId,
                    OrderId = order.Id
                };

                await _eTicaretDBContext.OrderProducts.AddAsync(productOrder);
                await _eTicaretDBContext.SaveChangesAsync();


            }

            return Json(new { success = true, message = "Sipariş başarıyla verildi!" });
        }

    }
}

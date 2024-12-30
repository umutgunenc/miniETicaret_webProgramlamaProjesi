using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        public async Task<IActionResult> AddCart(int id, int quantity)
        {

            // Sepete Girilen Miktarı Kontrol et
            if (quantity <= 0)
                return Json(new { success = false, message = "Sepete Minimum 1 Adet Ürün Eklenmelidir." });


            // Ürünü al ve stok kontrolü yap
            Product product = await _eTicaretDBContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return Json(new { success = false, message = "Ürün bulunamadı." });

            // Stok kontrolü
            if (quantity > product.StockCount)
            {
                return Json(new
                {
                    success = false,
                    message = $"Yetersiz stok. Mevcut stok: {product.StockCount}"
                });
            }

            // Kullanıcıyı al
            AppUser user = await _userManager.GetUserAsync(User);

            // Sepette aynı ürün var mı kontrol et
            Cart cartItem = await _eTicaretDBContext.Carts
                .FirstOrDefaultAsync(c => c.CustomerId == user.Id && c.ProductId == id);

            if (cartItem != null)
            {
                // Miktarı artır ve stok düşür
                if (cartItem.Quantity + quantity > product.StockCount)
                {
                    return Json(new
                    {
                        success = false,
                        message = $"Bu ürün zaten sepetinizde bulunmaktadır.\nMaksimum eklenebilir miktar: {product.StockCount - cartItem.Quantity}"
                    });
                }

                cartItem.Quantity += quantity;
                _eTicaretDBContext.Update(cartItem);
            }
            else
            {
                // Yeni bir sepet öğesi oluştur
                Cart newCart = new()
                {
                    CustomerId = user.Id,
                    ProductId = id,
                    Quantity = quantity
                };
                await _eTicaretDBContext.Carts.AddAsync(newCart);
            }

            // Veritabanı değişikliklerini kaydet
            await _eTicaretDBContext.SaveChangesAsync();

            return Json(new { success = true, message = "Ürün sepete başarıyla eklendi!" });
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
                Despriction = $"{customer.Name} {customer.SurName} -- {DateTime.Now.ToString("HH:mm dd.MM.yyyy")}"
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
                    OrderId = order.Id,
                    ProductUnitPrice = product.Price
                };

                await _eTicaretDBContext.OrderProducts.AddAsync(productOrder);
                await _eTicaretDBContext.SaveChangesAsync();
            }

            return Json(new { success = true, message = "Sipariş başarıyla verildi!" });
        }

    }
}

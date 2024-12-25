using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Seller;
using miniETicaret.Validators.Seller;
using System.IO;
using System.Threading.Tasks;

namespace miniETicaret.Controllers
{
    [Authorize(Roles = "SELLER")]
    public class SellerController : Controller
    {

        private readonly eTicaretDBContext _eTicaretDBContext;
        private readonly UserManager<AppUser> _userManager;

        public SellerController(eTicaretDBContext eTicaretDBContext, UserManager<AppUser> userManager)
        {
            _eTicaretDBContext = eTicaretDBContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            AddProductViewModel model = new(_eTicaretDBContext);
            model.Categories = await model.GetCategoriesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel model)
        {
            AddProductValidator validator = new();
            ValidationResult result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(model);
            }

            AppUser seller = await _userManager.GetUserAsync(User);

            var product = new Product
            {
                Name = model.Name.ToUpper(),
                Despriction = model.Despriction,
                Price = model.Price,
                CategoryId = model.CategoryId,
                SellerId = seller.Id,
                IsActive = true,
                StockCount = model.StockCount,
                ImgUrl = "empty"

            };

            await _eTicaretDBContext.Products.AddAsync(product);
            await _eTicaretDBContext.SaveChangesAsync();

            var productId = product.Id;

            // Fotoğraf uzantısını al
            var extension = Path.GetExtension(model.ProductPhoto.FileName);

            // Dosyanın yolunu belirle wwwroot altında images id.uzantı
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", $"{productId}{extension}");

            // Fotoğrafı kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.ProductPhoto.CopyToAsync(stream);
            }

            // Fotoğraf URLsini oluştur
            var photoUrl = $"/Images/{productId}{extension}";

            // Ürünü kaydederken product.ImgUrl = "empyt" olarak kaydedildi, bunu değiştir
            product.ImgUrl = photoUrl;

            // db yi güncelle
            _eTicaretDBContext.Update(product);
            await _eTicaretDBContext.SaveChangesAsync();

            TempData["ProductAdded"] = $"{product.Name} isimli ürün başarı ile kaydedildi.";
            return RedirectToAction("AddProduct");
        }
    }
}

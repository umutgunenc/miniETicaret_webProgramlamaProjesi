using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Seller;
using miniETicaret.Validators.Seller;
using System.IO;
using System.Linq;
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


        [HttpGet]
        public async Task<IActionResult> ShowSoldProducts()
        {

            AppUser seller = await _userManager.GetUserAsync(User);

            var query = _eTicaretDBContext.OrderProducts
                .Where(op => op.SellerId == seller.Id)
                .Include(op => op.Product)
                .Include(op => op.Order)
                    .ThenInclude(o => o.Customer)
                .Select(op => new ShowSoldProductsViewModel
                {
                    CustomerNameSurname = $"{op.Order.Customer.Name} {op.Order.Customer.SurName}",
                    CustomerAdress = op.Order.Customer.Address,
                    ProductName = op.Product.Name,
                    ProductUnitPrice = op.ProductUnitPrice,
                    ProductId = op.ProductId,
                    Quantity = op.Quantity,
                    TotalPrice = op.Quantity * op.ProductUnitPrice,
                    OrderDate = op.Order.OrderTime
                })
                .OrderByDescending(op=>op.OrderDate);

            var soldProducts = await query.ToListAsync();

            return View(soldProducts);

        }

        [HttpGet]
        public async Task<IActionResult> EditProduct()
        {
            var seller = await _userManager.GetUserAsync(User);

            var products = await _eTicaretDBContext.Products
                .Where(p => p.SellerId == seller.Id)
                .Select(p => new SellerProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockCount = p.StockCount,
                    ImgUrl = p.ImgUrl
                })
                .ToListAsync();

            return View("EditProduct", products); // Ürün listesini döndür
        }

        [HttpGet]
        public async Task<IActionResult> EditSingleProduct(int id)
        {

            AppUser seller = await _userManager.GetUserAsync(User);

            var product = await _eTicaretDBContext.Products
                .Where(p => p.Id == id && p.SellerId==seller.Id)
                .FirstOrDefaultAsync();

            if (product == null)
                return RedirectToAction("AccessDenied", "Error");

            var model = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Despriction = product.Despriction,
                Price = product.Price,
                StockCount = product.StockCount,
                CategoryId = product.CategoryId,
                CurrentImgUrl = product.ImgUrl,
                Categories = await _eTicaretDBContext.Categories
                    .Where(c => c.IsActive)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToListAsync()
            };

            return View("EditSingleProduct", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSingleProduct(EditProductViewModel model)
        {
            EditProductValidator validator = new();
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
            var product = await _eTicaretDBContext.Products
                .Where(p => p.Id == model.Id && p.SellerId == seller.Id)
                .FirstOrDefaultAsync();

            if (product == null)
                return RedirectToAction("AccessDenied", "Error");
            product.Name = model.Name.ToUpper(); ;
            product.Despriction = model.Despriction;
            product.Price = model.Price;
            product.StockCount = model.StockCount;
            product.CategoryId = model.CategoryId;

            

            //if (!ModelState.IsValid)
            //{
            //    model.Categories = await _eTicaretDBContext.Categories
            //        .Where(c => c.IsActive)
            //        .Select(c => new SelectListItem
            //        {
            //            Value = c.Id.ToString(),
            //            Text = c.Name
            //        }).ToListAsync();

            //    return View("EditSingleProduct", model);
            //}

            //var product = await _eTicaretDBContext.Products.FindAsync(model.Id);

            //if (product == null)
            //    return RedirectToAction("AccessDenied", "Error");
            //product.Name = model.Name;
            //product.Despriction = model.Despriction;
            //product.Price = model.Price;
            //product.StockCount = model.StockCount;
            //product.CategoryId = model.CategoryId;

            if (model.ProductPhoto != null)
            {
                var extension = Path.GetExtension(model.ProductPhoto.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", $"{product.Id}{extension}");

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProductPhoto.CopyToAsync(stream);
                }

                product.ImgUrl = $"/Images/{product.Id}{extension}";
            }

            _eTicaretDBContext.Update(product);
            await _eTicaretDBContext.SaveChangesAsync();

            TempData["ProductUpdated"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("EditProduct"); // Ürün listesini göster
        }


        //[HttpPost]
        //public async Task<IActionResult> EditProduct(EditProductViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        model.Categories = await _eTicaretDBContext.Categories
        //            .Where(c => c.IsActive)
        //            .Select(c => new SelectListItem
        //            {
        //                Value = c.Id.ToString(),
        //                Text = c.Name
        //            }).ToListAsync();

        //        return View("EditSingleProduct", model);
        //    }

        //    var product = await _eTicaretDBContext.Products.FindAsync(model.Id);

        //    if (product == null)
        //    {
        //        return NotFound("Ürün bulunamadı.");
        //    }

        //    product.Name = model.Name;
        //    product.Despriction = model.Despriction;
        //    product.Price = model.Price;
        //    product.StockCount = model.StockCount;
        //    product.CategoryId = model.CategoryId;

        //    if (model.ProductPhoto != null)
        //    {
        //        var extension = Path.GetExtension(model.ProductPhoto.FileName);
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", $"{product.Id}{extension}");
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await model.ProductPhoto.CopyToAsync(stream);
        //        }
        //        product.ImgUrl = $"/Images/{product.Id}{extension}";
        //    }

        //    _eTicaretDBContext.Update(product);
        //    await _eTicaretDBContext.SaveChangesAsync();

        //    TempData["ProductUpdated"] = "Ürün başarıyla güncellendi.";
        //    return RedirectToAction("EditProduct"); // Ürün listesini göster
        //}




    }
}

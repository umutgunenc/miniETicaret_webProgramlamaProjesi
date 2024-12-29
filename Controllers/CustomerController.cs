using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Customer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace miniETicaret.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly eTicaretDBContext _eTicaretDBContext;
        private readonly UserManager<AppUser> _userManager;

        public CustomerController(eTicaretDBContext eTicaretDBContext, UserManager<AppUser> userManager)
        {
            _eTicaretDBContext = eTicaretDBContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ShowCart()
        {
            AppUser user = await _userManager.GetUserAsync(User);

            ShowCartViewModel model = new(_eTicaretDBContext, user);

            model.Carts = await model.GetChartDetailsAsync();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> ShowOrders()
        {
            AppUser customer = await _userManager.GetUserAsync(User);

            var query = _eTicaretDBContext.Orders
                .Where(o => o.CustomerId == customer.Id)
                .Select(o => new ShowOrdersViewModel
                {
                    Id = o.Id,
                    OrderTime = o.OrderTime,
                    TotalPrice = o.TotalPrice
                });

            List<ShowOrdersViewModel> ordersViewModel = await query.ToListAsync();

            return View(ordersViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ShowOrderDetail(int id)
        {

            AppUser customer = await _userManager.GetUserAsync(User);

            var quertyOrderDetails = _eTicaretDBContext.OrderProducts
                .Include(op => op.Product)
                .Include(op => op.Seller)
                .Include(op => op.Order)
                .Where(op => op.OrderId == id && op.Order.CustomerId==customer.Id)
                .Select(op => new ShowOrderDetailViewModel
                {
                    OrderDate = op.Order.OrderTime,
                    SellerName = $"{op.Seller.Name} {op.Seller.SurName}",
                    ProductName = op.Product.Name,
                    ProductId = op.ProductId,
                    ProductUnitPrice = op.ProductUnitPrice,
                    Quantity = op.Quantity,
                    TotalProductPrice = op.Quantity * op.ProductUnitPrice
                });

            var orderDetails = await quertyOrderDetails.ToListAsync();

            return View(orderDetails);
        }

        // Müşteri Profilini Görüntüleme
        [HttpGet]
        public async Task<IActionResult> CustomerProfile()
        {
            // Kullanıcı bilgilerini al
            AppUser user = await _userManager.GetUserAsync(User);

            //if (user == null)
            //{
            //    return RedirectToAction("Login", "Account"); // Kullanıcı oturum açmamışsa yönlendir
            //}

            // Profil ViewModel'ini oluştur
            var model = new CustomerProfileViewModel
            {
                FullName = $"{user.Name} {user.SurName}",
                TCKN = user.TCKN,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                IsActive = user.IsActive
            };

            return View(model);
        }
    }
}

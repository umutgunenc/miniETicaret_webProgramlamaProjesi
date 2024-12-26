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
    public class CustomerController :Controller
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

            ShowCartViewModel model = new(_eTicaretDBContext,user);

            model.Carts = await model.GetChartDetailsAsync();

            return View(model);
        }
    }
}

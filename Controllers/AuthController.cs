using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Account;
using miniETicaret.Models.ViewModel.Auth;
using miniETicaret.Validators.Auth;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace miniETicaret.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly eTicaretDBContext _eTicaretDBContext;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, eTicaretDBContext eTicaretDBContext, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _eTicaretDBContext = eTicaretDBContext;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            LoginValidator validator = new();
            ValidationResult result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(model);
            }


            var user = await _userManager.FindByNameAsync(model.UserName);



            if (user == null)
            {
                ModelState.AddModelError("Password", "Kullanıcı adı veya şifre hatalı.");
                return View(model);
            }

            //Sayfa Kapatılınca Oturum Kapatılır 
            //Kullanıcı İstediği Kadar Yanlış Giriş Yapabilir
            var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("Password", "Kullanıcı adı veya şifre hatalı.");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(RegisterViewModel model)
        {
            RegisterValidator validator = new();
            ValidationResult result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(model);
            }
            model.Name = model.Name.ToUpper();
            model.SurName = model.SurName.ToUpper();
            model.IsActive = true;

            var identityResult = await _userManager.CreateAsync(model, model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
                return View(model);
            }

            IQueryable<int> userIdQuery = _eTicaretDBContext.Users
                .Where(u => u.UserName == model.UserName)
                .Select(u => u.Id);

            int userId = await userIdQuery.SingleOrDefaultAsync();

            await _eTicaretDBContext.UserRoles
                .AddAsync(new IdentityUserRole<int> { RoleId = 3, UserId = userId });

            await _eTicaretDBContext.SaveChangesAsync();

            TempData["RegisterCompleted"] = $"{model.UserName} kullanıcı adıyla yeni bir hesap oluşturuldu.";

            return View();

        }
        [HttpGet]
        public IActionResult RegisterSeller()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterSeller(RegisterViewModel model)
        {
            RegisterValidator validator = new();
            ValidationResult result = validator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(model);
            }
            model.Name = model.Name.ToUpper();
            model.SurName = model.SurName.ToUpper();
            model.IsActive = true;

            var identityResult = await _userManager.CreateAsync(model, model.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("Password", error.Description);
                }
                return View(model);
            }

            IQueryable<int> userIdQuery = _eTicaretDBContext.Users
                .Where(u => u.UserName == model.UserName)
                .Select(u => u.Id);

            int userId = await userIdQuery.SingleOrDefaultAsync();

            await _eTicaretDBContext.UserRoles
                .AddAsync(new IdentityUserRole<int> { RoleId = 2, UserId = userId });

            await _eTicaretDBContext.SaveChangesAsync();

            TempData["RegisterCompleted"] = $"{model.UserName} kullanıcı adıyla yeni bir hesap oluşturuldu.";

            return View();
        }
    }
}

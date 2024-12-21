using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using miniETicaret.Data;
using miniETicaret.Models.ViewModel.Admin;
using miniETicaret.Validators.Admin;
using System.Threading.Tasks;

namespace miniETicaret.Controllers
{
    public class AdminController : Controller
    {
        private readonly eTicaretDBContext _eTicaretDBContext;

        public AdminController(eTicaretDBContext eTicaretDBContext)
        {
            _eTicaretDBContext = eTicaretDBContext;
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel model)
        {

            AddCategoryValidator categoryValidator = new();
            ValidationResult result = categoryValidator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(model);
            }

            model.Name = model.Name.ToUpper();
            model.IsActive = true;

            await _eTicaretDBContext.Categories.AddAsync(model);
            await _eTicaretDBContext.SaveChangesAsync();


            TempData["CategoryAdded"] = $"{model.Name} isimli kategori başarı ile kaydedildi.";

            return View();
        }
    }
}

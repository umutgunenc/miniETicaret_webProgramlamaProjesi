using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniETicaret.Data;
using miniETicaret.Models.Entity;
using miniETicaret.Models.ViewModel.Admin;
using miniETicaret.Validators.Admin;
using System.Threading.Tasks;

namespace miniETicaret.Controllers
{
    [Authorize(Roles ="ADMIN")]
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

        [HttpGet]
        public async Task<IActionResult> EditCategory()
        {
            EditCategoryViewModel model = new(_eTicaretDBContext);

            model.Categories = await model.GetCategoriesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryViewModel model)
        {

            EditCategoryValidator editCategoryValidator = new();
            ValidationResult result = editCategoryValidator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(model);
            }

            var category = await _eTicaretDBContext.Categories.FindAsync(model.Id);


            return RedirectToAction("EditCategoryDetails", category);
        }

        [HttpGet]
        public IActionResult EditCategoryDetails(Category model)
        {

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategoryDetails(EditCategoryDetailsViewModel model)
        {
            EditCategoryDetailsValidator editCategoryDetailsValidator = new();
            ValidationResult result = editCategoryDetailsValidator.Validate(model);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(model);
            }

            model.Name = model.Name.ToUpper();
            _eTicaretDBContext.Categories.Update(model);
            await _eTicaretDBContext.SaveChangesAsync();

            TempData["CategoryEdited"] = "Kategori başarı ile düzenlendi.";

            return RedirectToAction("EditCategoryDetails",model);
        }
    }
}

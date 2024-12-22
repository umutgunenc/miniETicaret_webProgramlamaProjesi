using FluentValidation;
using miniETicaret.Models.ViewModel.Admin;

namespace miniETicaret.Validators.Admin
{
    public class EditCategoryValidator :AbstractValidator<EditCategoryViewModel>
    {
        public EditCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Lütfen Seçim Yapınız.")
                .NotNull().WithMessage("Lütfen Seçim Yapınız.")
                .Must(ValidatorFunctions.BeCategory).WithMessage("Seçilen Kategori Sistemde Bulunamadı.");
        }
    }
}

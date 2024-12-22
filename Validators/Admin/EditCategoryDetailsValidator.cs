using FluentValidation;
using miniETicaret.Models.ViewModel.Admin;

namespace miniETicaret.Validators.Admin
{
    public class EditCategoryDetailsValidator : AbstractValidator<EditCategoryDetailsViewModel>
    {
        public EditCategoryDetailsValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori Adını Giriniz")
                .NotNull().WithMessage("Kategori Adını Giriniz")
                .MaximumLength(256).WithMessage("Kategori Adı Maksimum 256 karakter Uzunluğunda Olabilir.")
                .Must((model, name) => ValidatorFunctions.BeUniqueCategoryName(name, model.Id))
                    .WithMessage("Bu İsimde Zaten Başka Bir Kayıt Mevcut.");
        }
    }
}

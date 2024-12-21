using FluentValidation;
using miniETicaret.Models.ViewModel.Admin;

namespace miniETicaret.Validators.Admin
{
    public class AddCategoryValidator :AbstractValidator<AddCategoryViewModel>
    {
        public AddCategoryValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Kategori Adını Giriniz")
                .NotNull().WithMessage("Kategori Adını Giriniz")
                .MaximumLength(256).WithMessage("Kategori Adı Maksimum 256 karakter Uzunluğunda Olabilir.")
                .Must(ValidatorFunctions.BeUniqueCategoryName).WithMessage("Aynı Isimde Bir Kategori Zaten Sisteme Eklenmiş Durumda");
        }
    }
}

using FluentValidation;
using miniETicaret.Models.ViewModel.Auth;

namespace miniETicaret.Validators.Auth
{
    public class LoginValidator :AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı Adını Giriniz.")
                .NotNull().WithMessage("Kullanıcı Adını Giriniz.")
                .MaximumLength(256).WithMessage("Kullanıcı Adını Maksimum 256 Karakter Uzunluğunda Olabilir");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Lütfen Şifrenizi Giriniz.")
                .NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz.")
                .MinimumLength(8).WithMessage("Şifre En Az 8 Karakter Olmalıdır.")
                .MaximumLength(50).WithMessage("Şifre Maksimum 50 Karakter Olabilir.");
        }
    }
}

using FluentValidation;
using miniETicaret.Models.ViewModel.Auth;
using System;
using System.Data;

namespace miniETicaret.Validators.Auth
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Lütfen Adınızı Giriniz.")
                .NotEmpty().WithMessage("Lütfen Adınızı Giriniz.")
                .MaximumLength(256).WithMessage("En Fazla 256 Karakter Uzunluğunda İsim Girilebilir.");

            RuleFor(x => x.SurName)
                .NotNull().WithMessage("Lütfen Soyadınızı Giriniz.")
                .NotEmpty().WithMessage("Lütfen Soyadınızı Giriniz.")
                .MaximumLength(256).WithMessage("En Fazla 256 Karakter Uzunluğunda Soyad Girilebilir.");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Lütfen E-Mail Adresinizi Giriniz.")
                .NotEmpty().WithMessage("Lütfen E-Mail Adresinizi Giriniz.")
                .EmailAddress().WithMessage("Lütfen Geçerli Bir E-Mail Adresi Giriniz.")
                .MaximumLength(256).WithMessage("En Fazla 256 Karakter Uzunluğunda E-Mail Adresi Girilebilir.")
                .Must(ValidatorFunctions.BeUniqueEmailAdress).WithMessage("Girilen E-Mail Zaten Sisteme Kayıtlı");

            RuleFor(x => x.TCKN)
                .NotNull().WithMessage("Lütfen Türkiye Cumhuriyeti Kimlik Numaranizi Giriniz.")
                .NotEmpty().WithMessage("Lütfen Türkiye Cumhuriyeti Kimlik Numaranizi Giriniz.")
                .MaximumLength(11).WithMessage("Türkiye Cumhuriyeti Kimlik Numarasi 11 Karakter Uzunluğundadır.")
                .MinimumLength(11).WithMessage("Türkiye Cumhuriyeti Kimlik Numarasi 11 Karakter Uzunluğundadır.")
                .Must(ValidatorFunctions.BeNumber).WithMessage("Türkiye Cumhuriyeti Kimlik Numarasi Rakamlardan Oluşmalıdır.")
                .Must(ValidatorFunctions.BeUniqueTCKN).WithMessage("Türkiye Cumhuriyeti Kimlik Numarasi Rakamlardan Oluşmalıdır.");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("Lütfen Telefon Numaranızı Giriniz.")
                .NotEmpty().WithMessage("Lütfen Telefon Numaranızı Giriniz.")
                .MaximumLength(13).WithMessage("TTelefon Nuamrası +905XXXXXX şeklinde 13 karakter uzunluğunda girilmelidir.")
                .MinimumLength(13).WithMessage("Telefon Nuamrası +905XXXXXX şeklinde 13 karakter uzunluğunda girilmelidir.")
                .Must(ValidatorFunctions.BeUniquePhoneNumber).WithMessage("Girilen Telefon Numarası Zaten Sisteme Kayıtlı.")
                .Must(ValidatorFunctions.BePhoneNumber).WithMessage("Girilen Telefon Numarası Geçersiz. Lütfen +905XXXXXX Şeklinde Telefon Numaranızı Giriniz.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Lütfen Adresinizi Giriniz.")
                .NotEmpty().WithMessage("Lütfen Adresinizi Giriniz.");

            RuleFor(x => x.UserName)
                .NotNull().WithMessage("Lütfen Kullanıcı Adınızı Giriniz.")
                .NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Giriniz.")
                .MaximumLength(256).WithMessage("Kullanıcı Adınız Maksimum 256 Karakter Uzunluğunda Olabilir.")
                .Must(ValidatorFunctions.BeUniqueUserName).WithMessage("Kullanıcı Adınız Sisteme Kayıtlı.");

            RuleFor(x => x.TermOfUse)
                .Equal(true).WithMessage("Kullanım Şartlarını Kabul Etmelisiniz.");


            RuleFor(x => x.Password)
                .NotNull().WithMessage("Lütfen Şifrenizi Giriniz.")
                .NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz.")
                .MinimumLength(8).WithMessage("Şifre En Az 8 Karakter Olmalıdır.")
                .MaximumLength(50).WithMessage("Şifre Maksimum 50 Karakter Olabilir.");
                //.Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                //.Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                //.Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                //.Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel işaret içermelidir.");

            RuleFor(x => x.ConfirmPassword)
                .NotNull().WithMessage("Lütfen Şifrenizi Tekrar Giriniz.")
                .NotEmpty().WithMessage("Lütfen Şifrenizi Tekrar Giriniz.")
                .Equal(x => x.Password).WithMessage("Şifreler Uyuşmuyor");

        }
    }
}

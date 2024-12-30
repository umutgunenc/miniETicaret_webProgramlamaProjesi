﻿using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using miniETicaret.Models.ViewModel.Seller;

namespace miniETicaret.Validators.Seller
{
    public class EditProductValidator :AbstractValidator<EditProductViewModel>
    {
        public EditProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Lütfen Ürün Adını Giriniz.")
                .NotEmpty().WithMessage("Lütfen Ürün Adını Giriniz.")
                .MaximumLength(256).WithMessage("Ürün Adı Maksimum 256 Karakter Uzunluğunda Olabilir.");

            RuleFor(x => x.Despriction)
                .NotNull().WithMessage("Lütfen Ürün Açıklamasını Giriniz.")
                .NotEmpty().WithMessage("Lütfen Ürün Açıklamasını Giriniz.");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Lütfen Ürün İçin Fiyat Giriniz.")
                .NotEmpty().WithMessage("Lütfen Ürün İçin Fiyat Giriniz.")
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.")
                .Must(x => ValidatorFunctions.IsValidDecimal(x.ToString()))
                .WithMessage("Lütfen Geçerli Bir Fiyat Giriniz.");

            RuleFor(x => x.StockCount)
                .NotNull().WithMessage("Lütfen Stok Miktarını Giriniz.")
                .NotEmpty().WithMessage("Lütfen Stok Miktarını Giriniz.")
                .GreaterThan(0).WithMessage("Stok Miktarı 0'dan büyük olmalıdır.")
                .Must(x => ValidatorFunctions.IsValidInteger(x.ToString()))
                .WithMessage("Lütfen Geçerli Bir Stok Miktarı Giriniz.");

            RuleFor(x => x.CategoryId)
            .NotNull().WithMessage("Lütfen Ürün İçin Kategori Seçiniz.")
            .NotEmpty().WithMessage("Lütfen Ürün İçin Kategori Seçiniz.")
            .Must(ValidatorFunctions.BeValidCategory).WithMessage("Lütfen Aktif Veya Kayıtlı Bir Kategori Seçiniz.");

            RuleFor(x => x.ProductPhoto)
                .Must(x => x?.Length < 10485760)  
                .When(x => x.ProductPhoto != null )  
                .WithMessage("Fotoğraf boyutu 10MB'dan küçük olmalıdır.");


            RuleFor(x => x.ProductPhoto)
                .Must(ValidatorFunctions.BeValidExtensionForPhoto)
                .When(x => x.ProductPhoto != null)
                .WithMessage("Sadece jpeg, jpg ve png türünde dosya yüklenebilir.");




        }
    }
}

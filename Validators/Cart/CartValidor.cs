using FluentValidation;
using miniETicaret.Models.ViewModel.Products;

namespace miniETicaret.Validators.Cart
{
    public class CartValidor : AbstractValidator<ProductsDetailViewModel>
    {
        public CartValidor()
        {
            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Lütfen Adet Giriniz.")
                .NotEmpty().WithMessage("Lütfen Adet Giriniz.")
                .GreaterThan(0).WithMessage("Girilen Miktar 0'dan Büyük Olmalı")
                .Must((model, quaintity) => ValidatorFunctions.HasEnoughStock(model, quaintity))
                .WithMessage("Stok Miktari Yetersiz, Sepetinize Daha Az Ürün Ekleyiniz");
        }
    }
}

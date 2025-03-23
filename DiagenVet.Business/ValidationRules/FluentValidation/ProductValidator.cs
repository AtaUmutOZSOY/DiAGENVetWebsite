using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Ürün adı boş geçilemez.")
            .MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

        RuleFor(p => p.ShortDescription)
            .NotEmpty().WithMessage("Kısa açıklama alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Kısa açıklama en az 10 karakter olmalıdır.")
            .MaximumLength(250).WithMessage("Kısa açıklama en fazla 250 karakter olabilir.");

        RuleFor(p => p.Slug)
            .NotEmpty().WithMessage("SEO URL boş geçilemez.")
            .Matches("^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("SEO URL sadece küçük harfler, rakamlar ve tire içerebilir.");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("Kategori seçimi zorunludur.");

        RuleFor(p => p.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");

        When(p => !string.IsNullOrEmpty(p.ImageUrl), () =>
        {
            RuleFor(p => p.ImageUrl)
                .Must(url => url.EndsWith(".jpg") || url.EndsWith(".jpeg") || url.EndsWith(".png"))
                .WithMessage("Geçersiz resim formatı. Sadece .jpg, .jpeg veya .png formatları kabul edilir.");
        });

        When(p => !string.IsNullOrEmpty(p.Specifications), () =>
        {
            RuleFor(p => p.Specifications)
                .MinimumLength(10).WithMessage("Özellikler en az 10 karakter olmalıdır.");
        });

        When(p => !string.IsNullOrEmpty(p.UsageInstructions), () =>
        {
            RuleFor(p => p.UsageInstructions)
                .MinimumLength(10).WithMessage("Kullanım talimatları en az 10 karakter olmalıdır.");
        });
    }
} 
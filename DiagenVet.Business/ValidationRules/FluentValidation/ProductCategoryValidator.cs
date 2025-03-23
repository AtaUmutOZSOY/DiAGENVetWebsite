using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class ProductCategoryValidator : AbstractValidator<ProductCategory>
{
    public ProductCategoryValidator()
    {
        RuleFor(pc => pc.Name)
            .NotEmpty().WithMessage("Kategori adı boş geçilemez.")
            .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

        RuleFor(pc => pc.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

        RuleFor(pc => pc.Slug)
            .NotEmpty().WithMessage("SEO URL boş geçilemez.")
            .Matches("^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("SEO URL sadece küçük harfler, rakamlar ve tire içerebilir.");

        RuleFor(pc => pc.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");

        When(pc => !string.IsNullOrEmpty(pc.ImageUrl), () =>
        {
            RuleFor(pc => pc.ImageUrl)
                .Must(url => url.EndsWith(".jpg") || url.EndsWith(".jpeg") || url.EndsWith(".png"))
                .WithMessage("Geçersiz resim formatı. Sadece .jpg, .jpeg veya .png formatları kabul edilir.");
        });

        When(pc => pc.ParentCategoryId.HasValue, () =>
        {
            RuleFor(pc => pc.ParentCategoryId)
                .Must((pc, parentId) => parentId != pc.Id)
                .WithMessage("Bir kategori kendisinin alt kategorisi olamaz.");
        });
    }
} 
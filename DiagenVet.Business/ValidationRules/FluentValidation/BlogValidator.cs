using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class BlogValidator : AbstractValidator<Blog>
{
    public BlogValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
            .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

        RuleFor(b => b.Content)
            .NotEmpty().WithMessage("İçerik alanı boş geçilemez.")
            .MinimumLength(100).WithMessage("İçerik en az 100 karakter olmalıdır.");

        RuleFor(b => b.Summary)
            .NotEmpty().WithMessage("Özet alanı boş geçilemez.")
            .MinimumLength(50).WithMessage("Özet en az 50 karakter olmalıdır.")
            .MaximumLength(300).WithMessage("Özet en fazla 300 karakter olabilir.");

        RuleFor(b => b.Slug)
            .NotEmpty().WithMessage("SEO URL boş geçilemez.")
            .Matches("^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("SEO URL sadece küçük harfler, rakamlar ve tire içerebilir.");

        RuleFor(b => b.Author)
            .NotEmpty().WithMessage("Yazar alanı boş geçilemez.")
            .MinimumLength(3).WithMessage("Yazar adı en az 3 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Yazar adı en fazla 50 karakter olabilir.");

        RuleFor(b => b.PublishDate)
            .NotEmpty().WithMessage("Yayın tarihi boş geçilemez.");

        RuleFor(b => b.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");

        When(b => !string.IsNullOrEmpty(b.ImageUrl), () =>
        {
            RuleFor(b => b.ImageUrl)
                .Must(url => url.EndsWith(".jpg") || url.EndsWith(".jpeg") || url.EndsWith(".png"))
                .WithMessage("Geçersiz resim formatı. Sadece .jpg, .jpeg veya .png formatları kabul edilir.");
        });

        When(b => !string.IsNullOrEmpty(b.Tags), () =>
        {
            RuleFor(b => b.Tags)
                .Must(tags => tags.Split(',').Length <= 10)
                .WithMessage("En fazla 10 etiket eklenebilir.");

            RuleFor(b => b.Tags)
                .Must(tags => tags.Split(',').All(tag => tag.Trim().Length >= 2 && tag.Trim().Length <= 20))
                .WithMessage("Her etiket en az 2, en fazla 20 karakter olmalıdır.");
        });
    }
} 
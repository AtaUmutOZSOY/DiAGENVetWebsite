using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class CertificateValidator : AbstractValidator<Certificate>
{
    public CertificateValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Sertifika adı boş geçilemez.")
            .MinimumLength(3).WithMessage("Sertifika adı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Sertifika adı en fazla 100 karakter olabilir.");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

        RuleFor(c => c.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");

        When(c => !string.IsNullOrEmpty(c.ImageUrl), () =>
        {
            RuleFor(c => c.ImageUrl)
                .Must(url => url.EndsWith(".jpg") || url.EndsWith(".jpeg") || url.EndsWith(".png"))
                .WithMessage("Geçersiz resim formatı. Sadece .jpg, .jpeg veya .png formatları kabul edilir.");
        });

        When(c => !string.IsNullOrEmpty(c.FileUrl), () =>
        {
            RuleFor(c => c.FileUrl)
                .Must(url => url.EndsWith(".pdf"))
                .WithMessage("Geçersiz dosya formatı. Sadece .pdf formatı kabul edilir.");
        });
    }
} 
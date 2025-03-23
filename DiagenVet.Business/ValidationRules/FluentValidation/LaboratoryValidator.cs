using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class LaboratoryValidator : AbstractValidator<Laboratory>
{
    public LaboratoryValidator()
    {
        RuleFor(l => l.Name)
            .NotEmpty().WithMessage("Laboratuvar adı boş geçilemez.")
            .MinimumLength(3).WithMessage("Laboratuvar adı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Laboratuvar adı en fazla 100 karakter olabilir.");

        RuleFor(l => l.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

        RuleFor(l => l.Equipment)
            .NotEmpty().WithMessage("Ekipman bilgisi boş geçilemez.")
            .MinimumLength(10).WithMessage("Ekipman bilgisi en az 10 karakter olmalıdır.");

        RuleFor(l => l.Capabilities)
            .NotEmpty().WithMessage("Yetenekler alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Yetenekler en az 10 karakter olmalıdır.");

        RuleFor(l => l.Accreditations)
            .NotEmpty().WithMessage("Akreditasyon bilgisi boş geçilemez.")
            .MinimumLength(10).WithMessage("Akreditasyon bilgisi en az 10 karakter olmalıdır.");

        RuleFor(l => l.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");

        When(l => !string.IsNullOrEmpty(l.ImageUrl), () =>
        {
            RuleFor(l => l.ImageUrl)
                .Must(url => url.EndsWith(".jpg") || url.EndsWith(".jpeg") || url.EndsWith(".png"))
                .WithMessage("Geçersiz resim formatı. Sadece .jpg, .jpeg veya .png formatları kabul edilir.");
        });
    }
} 
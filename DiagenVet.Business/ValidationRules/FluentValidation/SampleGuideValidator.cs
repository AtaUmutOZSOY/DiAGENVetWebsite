using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class SampleGuideValidator : AbstractValidator<SampleGuide>
{
    public SampleGuideValidator()
    {
        RuleFor(sg => sg.Title)
            .NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
            .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

        RuleFor(sg => sg.Content)
            .NotEmpty().WithMessage("İçerik alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("İçerik en az 10 karakter olmalıdır.");

        RuleFor(sg => sg.CollectionMethod)
            .NotEmpty().WithMessage("Toplama metodu boş geçilemez.")
            .MinimumLength(10).WithMessage("Toplama metodu en az 10 karakter olmalıdır.");

        RuleFor(sg => sg.StorageConditions)
            .NotEmpty().WithMessage("Saklama koşulları boş geçilemez.")
            .MinimumLength(10).WithMessage("Saklama koşulları en az 10 karakter olmalıdır.");

        RuleFor(sg => sg.TransportRequirements)
            .NotEmpty().WithMessage("Taşıma gereksinimleri boş geçilemez.")
            .MinimumLength(10).WithMessage("Taşıma gereksinimleri en az 10 karakter olmalıdır.");

        RuleFor(sg => sg.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");

        When(sg => !string.IsNullOrEmpty(sg.FileUrl), () =>
        {
            RuleFor(sg => sg.FileUrl)
                .Must(url => url.EndsWith(".pdf"))
                .WithMessage("Geçersiz dosya formatı. Sadece .pdf formatı kabul edilir.");
        });

        When(sg => !string.IsNullOrEmpty(sg.AdditionalNotes), () =>
        {
            RuleFor(sg => sg.AdditionalNotes)
                .MinimumLength(10).WithMessage("Ek notlar en az 10 karakter olmalıdır.");
        });
    }
} 
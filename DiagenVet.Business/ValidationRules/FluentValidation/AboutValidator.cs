using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class AboutValidator : AbstractValidator<About>
{
    public AboutValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
            .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

        RuleFor(a => a.Content)
            .NotEmpty().WithMessage("İçerik alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("İçerik en az 10 karakter olmalıdır.");

        RuleFor(a => a.Mission)
            .NotEmpty().WithMessage("Misyon alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Misyon en az 10 karakter olmalıdır.");

        RuleFor(a => a.Vision)
            .NotEmpty().WithMessage("Vizyon alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Vizyon en az 10 karakter olmalıdır.");

        RuleFor(a => a.Values)
            .NotEmpty().WithMessage("Değerler alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Değerler en az 10 karakter olmalıdır.");

        RuleFor(a => a.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");
    }
} 
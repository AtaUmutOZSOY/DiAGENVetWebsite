using DiagenVet.Entity.Concrete;
using FluentValidation;

namespace DiagenVet.Business.ValidationRules.FluentValidation;

public class TestValidator : AbstractValidator<Test>
{
    public TestValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Test adı boş geçilemez.")
            .MinimumLength(3).WithMessage("Test adı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Test adı en fazla 100 karakter olabilir.");

        RuleFor(t => t.Description)
            .NotEmpty().WithMessage("Açıklama alanı boş geçilemez.")
            .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

        RuleFor(t => t.Method)
            .NotEmpty().WithMessage("Test metodu boş geçilemez.")
            .MinimumLength(10).WithMessage("Test metodu en az 10 karakter olmalıdır.");

        RuleFor(t => t.SampleRequirements)
            .NotEmpty().WithMessage("Numune gereksinimleri boş geçilemez.")
            .MinimumLength(10).WithMessage("Numune gereksinimleri en az 10 karakter olmalıdır.");

        RuleFor(t => t.ProcessingTime)
            .NotEmpty().WithMessage("İşlem süresi boş geçilemez.")
            .MinimumLength(3).WithMessage("İşlem süresi en az 3 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("İşlem süresi en fazla 50 karakter olabilir.");

        RuleFor(t => t.ReportFormat)
            .NotEmpty().WithMessage("Rapor formatı boş geçilemez.")
            .MinimumLength(3).WithMessage("Rapor formatı en az 3 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Rapor formatı en fazla 50 karakter olabilir.");

        RuleFor(t => t.LaboratoryId)
            .NotEmpty().WithMessage("Laboratuvar seçimi zorunludur.");

        RuleFor(t => t.DisplayOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Görüntüleme sırası 0'dan küçük olamaz.");
    }
} 
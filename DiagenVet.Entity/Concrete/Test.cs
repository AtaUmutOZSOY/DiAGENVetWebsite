using DiagenVet.Core.Entities.Abstract;

namespace DiagenVet.Entity.Concrete;

public class Test : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string SampleRequirements { get; set; } = string.Empty;
    public string ProcessingTime { get; set; } = string.Empty;
    public string ReportFormat { get; set; } = string.Empty;
    public int LaboratoryId { get; set; }
    public int DisplayOrder { get; set; }
    
    // Navigation Property
    public virtual Laboratory Laboratory { get; set; } = null!;
} 
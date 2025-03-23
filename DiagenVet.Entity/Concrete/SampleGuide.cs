using DiagenVet.Core.Entities.Abstract;

namespace DiagenVet.Entity.Concrete;

public class SampleGuide : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string CollectionMethod { get; set; } = string.Empty;
    public string StorageConditions { get; set; } = string.Empty;
    public string TransportRequirements { get; set; } = string.Empty;
    public string? AdditionalNotes { get; set; }
    public string? FileUrl { get; set; }
    public int DisplayOrder { get; set; }
} 
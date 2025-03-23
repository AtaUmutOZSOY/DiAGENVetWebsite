using DiagenVet.Core.Entities.Abstract;

namespace DiagenVet.Entity.Concrete;

public class Certificate : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? FileUrl { get; set; }
    public int DisplayOrder { get; set; }
} 
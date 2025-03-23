using DiagenVet.Core.Entities.Abstract;

namespace DiagenVet.Entity.Concrete;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string? Specifications { get; set; }
    public string? UsageInstructions { get; set; }
    public int CategoryId { get; set; }
    public int DisplayOrder { get; set; }
    
    // Navigation Property
    public virtual ProductCategory Category { get; set; } = null!;
} 
using DiagenVet.Core.Entities.Abstract;

namespace DiagenVet.Entity.Concrete;

public class About : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string Mission { get; set; } = string.Empty;
    public string Vision { get; set; } = string.Empty;
    public string Values { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
} 
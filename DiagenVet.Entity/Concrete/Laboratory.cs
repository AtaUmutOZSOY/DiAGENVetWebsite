using DiagenVet.Core.Entities.Abstract;
using System.Collections.Generic;

namespace DiagenVet.Entity.Concrete;

public class Laboratory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string Equipment { get; set; } = string.Empty;
    public string Capabilities { get; set; } = string.Empty;
    public string Accreditations { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
    
    // Navigation Properties
    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
} 
using DiagenVet.Core.Entities.Abstract;
using System.Collections.Generic;

namespace DiagenVet.Entity.Concrete;

public class ProductCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string Slug { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
    public int? ParentCategoryId { get; set; }
    
    // Navigation Properties
    public virtual ProductCategory? ParentCategory { get; set; }
    public virtual ICollection<ProductCategory> SubCategories { get; set; } = new List<ProductCategory>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
} 
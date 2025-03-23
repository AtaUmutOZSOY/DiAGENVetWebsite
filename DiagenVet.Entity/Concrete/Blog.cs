using DiagenVet.Core.Entities.Abstract;
using System;

namespace DiagenVet.Entity.Concrete;

public class Blog : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public bool IsPublished { get; set; }
    public string? Tags { get; set; }
    public int ViewCount { get; set; }
    public int DisplayOrder { get; set; }
} 
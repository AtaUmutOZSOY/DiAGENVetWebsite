using DiagenVet.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DiagenVet.DataAccess.Contexts;

public class DiagenVetContext : DbContext
{
    public DiagenVetContext(DbContextOptions<DiagenVetContext> options) : base(options)
    {
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Laboratory> Laboratories { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<SampleGuide> SampleGuides { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ProductCategory self-referencing relationship
        modelBuilder.Entity<ProductCategory>()
            .HasOne(c => c.ParentCategory)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentCategoryId);

        // Product - ProductCategory relationship
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        // Laboratory - Test relationship
        modelBuilder.Entity<Test>()
            .HasOne(t => t.Laboratory)
            .WithMany(l => l.Tests)
            .HasForeignKey(t => t.LaboratoryId);

        base.OnModelCreating(modelBuilder);
    }
} 
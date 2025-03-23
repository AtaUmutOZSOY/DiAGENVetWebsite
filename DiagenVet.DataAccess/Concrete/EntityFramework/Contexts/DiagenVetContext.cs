using DiagenVet.Core.Entities.Concrete;
using DiagenVet.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DiagenVet.DataAccess.Concrete.EntityFramework.Contexts;

public class DiagenVetContext : DbContext
{
    public DiagenVetContext(DbContextOptions<DiagenVetContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=DiagenVetDB;User=root;Password=12345;",
                ServerVersion.AutoDetect("Server=localhost;Database=DiagenVetDB;User=root;Password=12345;"));
        }
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Laboratory> Laboratories { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<SampleGuide> SampleGuides { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

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
using DiagenVet.Core.Entities.Concrete;
using DiagenVet.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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

        // User - UserOperationClaim relationship
        modelBuilder.Entity<UserOperationClaim>()
            .HasOne(uoc => uoc.User)
            .WithMany(u => u.UserOperationClaims)
            .HasForeignKey(uoc => uoc.UserId);

        // OperationClaim - UserOperationClaim relationship
        modelBuilder.Entity<UserOperationClaim>()
            .HasOne(uoc => uoc.OperationClaim)
            .WithMany(oc => oc.UserOperationClaims)
            .HasForeignKey(uoc => uoc.OperationClaimId);

        // Seed initial data
        modelBuilder.Entity<OperationClaim>().HasData(
            new OperationClaim { Id = 1, Name = "Admin" },
            new OperationClaim { Id = 2, Name = "User" }
        );

        base.OnModelCreating(modelBuilder);
    }
}

public class DiagenVetContextFactory : IDesignTimeDbContextFactory<DiagenVetContext>
{
    public DiagenVetContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DiagenVetContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        optionsBuilder.UseMySql("Server=localhost;Database=DiagenVetDB;User=root;Password=reostaspytr7B.!;",
            serverVersion);

        return new DiagenVetContext(optionsBuilder.Options);
    }
} 
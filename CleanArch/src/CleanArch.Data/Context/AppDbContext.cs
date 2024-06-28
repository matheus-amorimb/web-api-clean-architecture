using CleanArch.Data.EntitiesConfiguration;
using CleanArch.Data.Utilities;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
    { }
    
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("category");
        modelBuilder.Entity<Category>().RenameColumnsNameToLower();
        modelBuilder.Entity<Product>().ToTable("product");
        modelBuilder.Entity<Product>().HasOne(product => product.Category).WithMany(category => category.Products).HasForeignKey()
            .IsRequired();
        modelBuilder.Entity<Product>().RenameColumnsNameToLower();
        base.OnModelCreating(modelBuilder);
    }
}
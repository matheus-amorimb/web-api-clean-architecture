using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Data.EntitiesConfiguration;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);
        
        builder.Property(category => category.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasData(
            new Category(Guid.NewGuid(), "Electronics"),
            new Category(Guid.NewGuid(), "Clothing"),
            new Category(Guid.NewGuid(), "Camping & Hiking")
        );
    }
}
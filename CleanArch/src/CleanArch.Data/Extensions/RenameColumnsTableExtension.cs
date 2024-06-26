using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Data.Utilities;

public static class RenameColumnsTableExtension
{
    public static void RenameColumnsNameToLower<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T : class
    {
        foreach (var property in typeof(T).GetProperties().Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string)))
        {
            entityTypeBuilder.Property(property.Name).HasColumnName(property.Name.ToLower());
        }
    }
}
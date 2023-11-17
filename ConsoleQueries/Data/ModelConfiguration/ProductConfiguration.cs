using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");

        builder.HasIndex(e => e.Name, "namep")
            .IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.AverageRating).HasColumnName("average_rating");

        builder.Property(e => e.BrandId).HasColumnName("brand_id");

        builder.Property(e => e.CategoryId).HasColumnName("category_id");

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.Property(e => e.Price).HasColumnName("price");

        builder.HasOne(d => d.Brand)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.BrandId)
            .HasConstraintName("brand_idс");

        builder.HasOne(d => d.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .HasConstraintName("category_idс");
    }
}
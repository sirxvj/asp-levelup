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

        builder.Property(e => e.Name)
            .HasMaxLength(50);


        builder.HasOne(d => d.Brand)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.BrandId);

        builder.HasOne(d => d.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId);
    }
}
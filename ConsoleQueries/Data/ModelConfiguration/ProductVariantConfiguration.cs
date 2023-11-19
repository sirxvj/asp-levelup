using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class ProductVariantConfiguration:IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("product_variant");

        builder.HasOne(d => d.Color)
            .WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.ColorId);

        builder.HasOne(d => d.Product)
            .WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.ProductId);

        builder.HasOne(d => d.Size)
            .WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.SizeId);
    }
}
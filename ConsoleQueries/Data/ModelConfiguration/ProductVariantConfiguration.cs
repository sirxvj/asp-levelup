using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class ProductVariantConfiguration:IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("product_variant");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.ColorId).HasColumnName("color_id");

        builder.Property(e => e.ProductId).HasColumnName("product_id");

        builder.Property(e => e.Quantity).HasColumnName("quantity");

        builder.Property(e => e.SizeId).HasColumnName("size_id");

        builder.HasOne(d => d.Color)
            .WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.ColorId)
            .HasConstraintName("color_idс");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("product_idс");

        builder.HasOne(d => d.Size)
            .WithMany(p => p.ProductVariants)
            .HasForeignKey(d => d.SizeId)
            .HasConstraintName("size_idс");
    }
}
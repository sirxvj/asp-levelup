using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class OrderItemConfiguration:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(e => new { e.ProductVariantId, e.OrderId })
            .HasName("order_items_pkey");

        builder.ToTable("order_items");

        builder.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

        builder.Property(e => e.OrderId).HasColumnName("order_id");

        builder.Property(e => e.Quantity).HasColumnName("quantity");

        builder.HasOne(d => d.Order)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("order_idс");

        builder.HasOne(d => d.ProductVariant)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.ProductVariantId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("product_variant_idс");
    }
}
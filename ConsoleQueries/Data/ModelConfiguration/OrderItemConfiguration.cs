using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class OrderItemConfiguration:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(e => new { e.ProductVariantId, e.OrderId });

        builder.ToTable("order_items");

        builder.HasOne(d => d.Order)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(d => d.ProductVariant)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(d => d.ProductVariantId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
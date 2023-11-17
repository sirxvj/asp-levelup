using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class CartItemConfiguration:IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(e => new { e.ProductVariantId, e.UserId })
            .HasName("cart_items_pkey");

        builder.ToTable("cart_items");

        builder.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.Property(e => e.Quantity).HasColumnName("quantity");

        builder.HasOne(d => d.ProductVariant)
            .WithMany(p => p.CartItems)
            .HasForeignKey(d => d.ProductVariantId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("product_variant_idс");

        builder.HasOne(d => d.User)
            .WithMany(p => p.CartItems)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("user_idс");
    }
}
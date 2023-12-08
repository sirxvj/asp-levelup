using ConsoleQueries.Domain.Entities;
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
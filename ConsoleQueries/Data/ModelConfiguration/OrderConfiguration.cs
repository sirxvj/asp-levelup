using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");
                
        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.AddressId).HasColumnName("address_id");
        builder.Property(e => e.status)
            .HasConversion<int>();
                    
                
        builder.Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

        builder.Property(e => e.Price).HasColumnName("price");

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.HasOne(d => d.Address)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.AddressId)
            .HasConstraintName("address_idс");

        builder.HasOne(d => d.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("user_idс");
    }
}
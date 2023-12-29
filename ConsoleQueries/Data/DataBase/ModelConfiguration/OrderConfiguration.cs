using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");
                
        builder.Property(e => e.Status)
            .HasConversion<int>();
                    
                
        builder.Property(e => e.CreatedAt)
            .HasColumnType("timestamp without time zone");

       
        builder.HasOne(d => d.Address)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.AddressId);

        builder.HasOne(d => d.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.UserId);
    }
}
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class OrderTransactionConfiguration:IEntityTypeConfiguration<OrderTransaction>
{
    public void Configure(EntityTypeBuilder<OrderTransaction> builder)
    {
        builder.HasKey(e => e.OrderId);

        builder.ToTable("order_transactions");

        builder.Property(e => e.OrderId)
            .ValueGeneratedNever();

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone");

        builder.HasOne(d => d.Order)
            .WithOne(p => p.OrderTransaction)
            .HasForeignKey<OrderTransaction>(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
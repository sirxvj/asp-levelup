using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class OrderTransactionConfiguration:IEntityTypeConfiguration<OrderTransaction>
{
    public void Configure(EntityTypeBuilder<OrderTransaction> builder)
    {
        builder.HasKey(e => e.OrderId)
            .HasName("order_transactions_pkey");

        builder.ToTable("order_transactions");

        builder.Property(e => e.OrderId)
            .ValueGeneratedNever()
            .HasColumnName("order_id");

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");

        builder.HasOne(d => d.Order)
            .WithOne(p => p.OrderTransaction)
            .HasForeignKey<OrderTransaction>(d => d.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("order_idс");
    }
}
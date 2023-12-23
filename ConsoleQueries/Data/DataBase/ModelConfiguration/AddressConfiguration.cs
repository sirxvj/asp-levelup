using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");
        
        builder.Property(e => e.Address1)
            .HasMaxLength(50)
            .HasColumnName("address");

        builder.Property(e => e.City)
            .HasMaxLength(30)
            .HasColumnName("city");

        builder.Property(e => e.Country)
            .HasMaxLength(30)
            .HasColumnName("country");

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.HasOne(d => d.User)
            .WithMany(p => p.Addresses)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("user_id");
    }
}
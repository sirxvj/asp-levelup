using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class BrandConfiguration: IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("brand");

        builder.HasIndex(e => e.Name, "nameb")
            .IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Name)
            .HasMaxLength(50);
    }
}
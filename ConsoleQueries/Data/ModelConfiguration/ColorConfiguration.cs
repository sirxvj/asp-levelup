using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class ColorConfiguration:IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("color");

        builder.HasIndex(e => e.Name, "nameс")
            .IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Name)
            .HasMaxLength(50);
    }
}
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class SizeConfiguration:IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("size");

        builder.HasIndex(e => e.Name, "names")
            .IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
    }
}
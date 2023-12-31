using ConsoleQueries.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.DataBase.ModelConfiguration;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasIndex(e => e.Email, "emailс")
            .IsUnique();

        builder.HasIndex(e => e.Phone, "phoneс")
            .IsUnique();

        builder.Property(e => e.Id);

        builder.Property(e => e.Email)
            .HasMaxLength(30);

        builder.Property(e => e.FirstName)
            .HasMaxLength(30);

        builder.Property(e => e.LastName)
            .HasMaxLength(30);

        builder.Property(e => e.Password)
            .HasMaxLength(50);

        builder.Property(e => e.Phone)
            .HasMaxLength(20);

        builder.Property(e => e.Username)
            .HasMaxLength(30);
        builder.Property(e => e.type)
            .HasConversion<int>();
    }
}
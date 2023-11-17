using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasIndex(e => e.Email, "emailс")
            .IsUnique();

        builder.HasIndex(e => e.Phone, "phoneс")
            .IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Email)
            .HasMaxLength(30)
            .HasColumnName("email");

        builder.Property(e => e.FirstName)
            .HasMaxLength(30)
            .HasColumnName("first_name");

        builder.Property(e => e.LastName)
            .HasMaxLength(30)
            .HasColumnName("last_name");

        builder.Property(e => e.Password)
            .HasMaxLength(50)
            .HasColumnName("password");

        builder.Property(e => e.Phone)
            .HasMaxLength(20)
            .HasColumnName("phone");

        builder.Property(e => e.Username)
            .HasMaxLength(30)
            .HasColumnName("username");
        builder.Property(e => e.type)
            .HasConversion<int>();
    }
}
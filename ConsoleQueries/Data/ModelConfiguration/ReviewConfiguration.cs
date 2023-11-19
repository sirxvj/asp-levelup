using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class ReviewConfiguration:IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("review");

        
        builder.Property(e => e.Comment)
            .HasMaxLength(2000);

        builder.Property(e => e.Date)
            .HasColumnType("timestamp without time zone");

        
        builder.Property(e => e.Titile)
            .HasMaxLength(50);

        builder.HasOne(d => d.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.ProductId);

        builder.HasOne(d => d.User)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.UserId);
    }
}
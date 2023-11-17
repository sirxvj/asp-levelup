using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class ReviewConfiguration:IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("review");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Comment)
            .HasMaxLength(2000)
            .HasColumnName("comment");

        builder.Property(e => e.Date)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("date");

        builder.Property(e => e.ProductId).HasColumnName("product_id");

        builder.Property(e => e.Rating).HasColumnName("rating");

        builder.Property(e => e.Titile)
            .HasMaxLength(50)
            .HasColumnName("titile");

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("product_idс");

        builder.HasOne(d => d.User)
            .WithMany(p => p.Reviews)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("user_idс");
    }
}
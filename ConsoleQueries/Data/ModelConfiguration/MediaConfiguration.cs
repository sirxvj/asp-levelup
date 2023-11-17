using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class MediaConfiguration:IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.ToTable("media");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Bytes).HasColumnName("bytes");

        builder.Property(e => e.FileName)
            .HasMaxLength(50)
            .HasColumnName("file_name");

        builder.Property(e => e.FileType)
            .HasMaxLength(50)
            .HasColumnName("file_type");

        builder.Property(e => e.ProductId).HasColumnName("product_id");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.Media)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("media_product_id_fkey");
    }
}
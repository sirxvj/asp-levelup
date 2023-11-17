using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class SectionConfiguration:IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("section");

        builder.HasIndex(e => e.Name, "namese")
            .IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.HasMany(d => d.Categories)
            .WithMany(p => p.Sections)
            .UsingEntity<Dictionary<string, object>>(
                "SectionToCategory",
                l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("category_idс"),
                r => r.HasOne<Section>().WithMany().HasForeignKey("SectionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("section_idс"),
                j =>
                {
                    j.HasKey("SectionId", "CategoryId").HasName("section_to_category_pkey");

                    j.ToTable("section_to_category");

                    j.IndexerProperty<short>("SectionId").HasColumnName("section_id");

                    j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                });
    }
}
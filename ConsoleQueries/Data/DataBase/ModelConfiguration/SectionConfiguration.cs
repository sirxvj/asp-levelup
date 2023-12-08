using ConsoleQueries.Domain.Entities;
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

        
        builder.Property(e => e.Name)
            .HasMaxLength(50);

        builder.HasMany(d => d.Categories)
            .WithMany(p => p.Sections)
            .UsingEntity<Dictionary<string, object>>(
                "SectionToCategory",
                l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull),
                r => r.HasOne<Section>().WithMany().HasForeignKey("SectionId").OnDelete(DeleteBehavior.ClientSetNull),
                j =>
                {
                    j.HasKey("SectionId", "CategoryId");

                    j.ToTable("section_to_category");

                    j.IndexerProperty<short>("SectionId");

                    j.IndexerProperty<int>("CategoryId");
                });
    }
}
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleQueries.Data.ModelConfiguration;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");

        builder.HasIndex(e => e.Name, "nameсa")
            .IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Name)
            .HasMaxLength(40)
            .HasColumnName("name");

        builder.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

        builder.HasOne(d => d.ParentCategory)
            .WithMany(p => p.InverseParentCategory)
            .HasForeignKey(d => d.ParentCategoryId)
            .HasConstraintName("parent_category_idс");
    }
}
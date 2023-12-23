using System.ComponentModel.DataAnnotations;
using ConsoleQueries.Models;
using FluentValidation;

namespace ConsoleQueries.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int? ParentCategoryId { get; set; }

        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}

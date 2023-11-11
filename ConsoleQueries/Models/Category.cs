using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseParentCategory = new HashSet<Category>();
            Products = new HashSet<Product>();
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}

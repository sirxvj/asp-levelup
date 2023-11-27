﻿using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}

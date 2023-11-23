using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class Size
    {
        public Size()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Price { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public short? AverageRating { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Media> Media { get; set; } = new List<Media>();
        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}

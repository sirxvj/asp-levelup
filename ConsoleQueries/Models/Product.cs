using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class Product
    {
        public Product()
        {
            Media = new HashSet<Media>();
            ProductVariants = new HashSet<ProductVariant>();
            Reviews = new HashSet<Review>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Price { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public short? AverageRating { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class ProductVariant
    {
        public ProductVariant()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public long Id { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Color? Color { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Size? Size { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

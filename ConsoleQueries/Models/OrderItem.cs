using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class OrderItem
    {
        public long ProductVariantId { get; set; }
        public long OrderId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ProductVariant ProductVariant { get; set; } = null!;
    }
}

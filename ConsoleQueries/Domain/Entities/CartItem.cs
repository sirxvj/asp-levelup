using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.Entities
{
    public class CartItem
    {
        public long ProductVariantId { get; set; }
        public long UserId { get; set; }
        public int? Quantity { get; set; }
        public virtual ProductVariant ProductVariant { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

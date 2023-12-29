using ConsoleQueries.Models;

namespace ConsoleQueries.Domain.Entities
{
    public class OrderTransaction
    {
        public long OrderId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public Status Status { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}

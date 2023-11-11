using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public long Id { get; set; }
        public long? UserId { get; set; }
        public int? Price { get; set; }
        public long? AddressId { get; set; }
        public Status status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Address? Address { get; set; }
        public virtual User? User { get; set; }
        public virtual OrderTransaction? OrderTransaction { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

    public enum Status:int
    {
     InReview=0,
     InDelivery=1,
     Completed=2
    }
}

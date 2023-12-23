using System;
using System.Collections.Generic;
using ConsoleQueries.Domain.Entities;

namespace ConsoleQueries.Models
{
    public partial class Order
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public int? Price { get; set; }
        public long? AddressId { get; set; }
        public Status Status { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Address? Address { get; set; }
        public virtual User? User { get; set; }
        public virtual OrderTransaction? OrderTransaction { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

    public enum Status:int
    {
     InReview=0,
     InDelivery=1,
     Completed=2
    }
}

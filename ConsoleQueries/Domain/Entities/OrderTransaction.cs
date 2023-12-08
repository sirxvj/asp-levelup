using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public class OrderTransaction
    {
        public long OrderId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public Status status { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}

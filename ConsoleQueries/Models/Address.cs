using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string? Address1 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public long? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public class User
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public UserType type { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }

    public enum UserType:int
    {
        Customer=0,
        Admin=1
    }
}

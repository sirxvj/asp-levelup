using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            CartItems = new HashSet<CartItem>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }

        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        public admin type { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }

    public enum admin:int
    {
        Customer=0,
        Admin=1
    }
}

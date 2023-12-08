using System;
using System.Collections.Generic;
using ConsoleQueries.Domain.Entities;
using FluentValidation;

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
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty();
            RuleFor(x => x.Phone).Length(8,20);
            RuleFor(x => x.Username).Length(2, 30);
            RuleFor(x => x.Email).Length(3, 30);
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
        }
    }
}

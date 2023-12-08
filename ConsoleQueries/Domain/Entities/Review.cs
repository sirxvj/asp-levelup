using System;
using System.Collections.Generic;
using ConsoleQueries.Domain.Entities;
using FluentValidation;

namespace ConsoleQueries.Models
{
    public class Review
    {
        public long Id { get; set; }
        public short? Rating { get; set; }
        public string? Titile { get; set; }
        public string? Comment { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
    public class ReviewsValidator : AbstractValidator<Review>
    {
        public ReviewsValidator()
        {
            RuleFor(x => x.Titile).NotNull().NotEmpty();
            RuleFor(x => x.Comment).NotNull().NotEmpty();
            RuleFor(x => x.Titile).Length(2, 50);
            RuleFor(x => x.Comment).Length(2, 2000);
            RuleFor(x => x.Rating).InclusiveBetween((short)0, (short)5);
            RuleFor(x => x.Date).InclusiveBetween(new DateTime(2023), DateTime.Now);
        }
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class ReviewsForProduct
    {
        public short? Rating { get; set; }
        public string? Comment { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

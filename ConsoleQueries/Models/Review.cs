using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class Review
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
}

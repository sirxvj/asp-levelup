using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public class Media
    {
        public int Id { get; set; }
        public long? ProductId { get; set; }
        public byte[]? Bytes { get; set; }
        public string? FileType { get; set; }
        public string? FileName { get; set; }

        public virtual Product? Product { get; set; }
    }
}

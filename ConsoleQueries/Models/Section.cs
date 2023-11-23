using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public class Section
    {
        public short Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}

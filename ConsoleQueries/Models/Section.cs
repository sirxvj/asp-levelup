using System;
using System.Collections.Generic;

namespace ConsoleQueries.Models
{
    public partial class Section
    {
        public Section()
        {
            Categories = new HashSet<Category>();
        }

        public short Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}

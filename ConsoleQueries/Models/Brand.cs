﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleQueries.Models
{
    public class Brand
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

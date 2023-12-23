using System.ComponentModel.DataAnnotations;
using ConsoleQueries.Models;
using FluentValidation;

namespace ConsoleQueries.Domain.Entities
{
    public class Section
    {
        public short Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}

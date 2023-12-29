using System.Reflection;
using ConsoleQueries.Domain.Entities;
using ConsoleQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleQueries.Data.DataBase
{
    public partial class DataBaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Media> Media { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<OrderTransaction> OrderTransactions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductVariant> ProductVariants { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Status>().HasPostgresEnum<UserType>(); 

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            
        } 
    }
}

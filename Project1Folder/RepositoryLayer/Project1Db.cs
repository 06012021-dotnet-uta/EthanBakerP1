using System;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace RepositoryLayer
{
    public class Project1Db : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Inventory> Inventory { get; set; }





        public Project1Db() { }
        public Project1Db(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=project1;Trusted_Connection=True;");
            }
        }

    }
}

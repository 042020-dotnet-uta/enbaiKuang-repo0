using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project0.Models;

namespace Project0
{
    public class P0DbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public P0DbContext() { }

        public P0DbContext(DbContextOptions<P0DbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source = storeApp.db");
            }
        }
    }
}

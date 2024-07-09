using ECommerceApp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ProductMicroService.DataAccessLayer.Context
{
    public class ProductDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial catalog=ECommerceProductDb;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Product and Category
            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId);
        }
    }
}

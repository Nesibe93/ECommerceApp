using ECommerceApp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.CategoryMicroservice.DataAccessLayer.Context
{
    public class CategoryDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial catalog=ECommerceDb;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

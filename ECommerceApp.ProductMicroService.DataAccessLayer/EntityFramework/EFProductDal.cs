using ECommerceApp.EntityLayer.Concrete;
using ECommerceApp.EntityLayer.Dtos.CategoryDtos;
using ECommerceApp.EntityLayer.Dtos.ProductDtos;
using ECommerceApp.ProductMicroService.DataAccessLayer.Abstract;
using ECommerceApp.ProductMicroService.DataAccessLayer.Context;
using ECommerceApp.ProductMicroService.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ProductMicroService.DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public List<Product> GetByProductWithCategory()
        {
            using (var context = new ProductDbContext())
            {
                var values = context.Products
                                    .Include(x => x.Category)
                                    .Select(y => new Product
                                    {
                                        ProductId = y.ProductId,
                                        ProductName = y.ProductName,
                                        CategoryId = y.CategoryId,
                                        Price = y.Price,
                                        Category = new Category
                                        {
                                            CategoryName = y.Category.CategoryName
                                        }
                                    })
                                    .ToList();
                return values;
            }
        }

        public Product GetByProductId(int id)
        {
            using (var context = new ProductDbContext())
            {
                var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
                return product;
            }
        }
    }
}

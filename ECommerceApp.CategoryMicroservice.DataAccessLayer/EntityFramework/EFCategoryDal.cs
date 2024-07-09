using ECommerceApp.CategoryMicroservice.DataAccessLayer.Abstract;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.Context;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.Repositories;
using ECommerceApp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerceApp.CategoryMicroservice.DataAccessLayer.EntityFramework
{
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(CategoryDbContext context) : base(context)
        {

        }
        public string GetByCategoryName()
        {
            using (var context = new CategoryDbContext())
            {
                var category = context.Categories.FirstOrDefault();
                if (category != null)
                {
                    return category.CategoryName;
                }
                return null; // Kategori bulunamazsa null döner
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.EntityLayer.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public class Category
        {
            public string CategoryName { get; set; }
        }
    }
}

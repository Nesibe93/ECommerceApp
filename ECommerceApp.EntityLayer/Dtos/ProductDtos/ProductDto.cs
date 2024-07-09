using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.EntityLayer.Dtos.ProductDtos
{
    public class ProductDto
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}

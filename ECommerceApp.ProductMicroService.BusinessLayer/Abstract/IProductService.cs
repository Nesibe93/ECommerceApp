using ECommerceApp.EntityLayer.Concrete;
using ECommerceApp.EntityLayer.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ProductMicroService.BusinessLayer.Abstract
{
    public interface IProductService: IGenericService<Product>
    {
        public List<Product> TGetByProductWithCategory();
    }
}

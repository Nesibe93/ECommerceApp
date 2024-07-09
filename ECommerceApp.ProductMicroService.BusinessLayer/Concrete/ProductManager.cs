using ECommerceApp.EntityLayer.Concrete;
using ECommerceApp.EntityLayer.Dtos.ProductDtos;
using ECommerceApp.ProductMicroService.BusinessLayer.Abstract;
using ECommerceApp.ProductMicroService.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ProductMicroService.BusinessLayer.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> TGetByProductWithCategory()
        {
            return _productDal.GetByProductWithCategory();
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

    }
}

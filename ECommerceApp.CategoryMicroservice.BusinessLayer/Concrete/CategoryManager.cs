using ECommerceApp.CategoryMicroservice.BusinessLayer.Abstract;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.Abstract;
using ECommerceApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.CategoryMicroservice.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);
        }

        public string TGetByCategoryName() // int string yaptım
        {
            return _categoryDal.GetByCategoryName();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}

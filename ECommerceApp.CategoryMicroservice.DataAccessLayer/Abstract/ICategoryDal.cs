using ECommerceApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.CategoryMicroservice.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        public string GetByCategoryName();
    }
}

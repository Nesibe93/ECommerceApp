using ECommerceApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.CategoryMicroservice.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public string TGetByCategoryName();
    }
}

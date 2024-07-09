using ECommerceApp.CategoryMicroservice.DataAccessLayer.Abstract;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.Context;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.CategoryMicroservice.DataAccessLayer.EntityFramework
{
    public class EFGenericDal<T> : IGenericDal<T> where T : class
    {
        private readonly CategoryDbContext _context;
        private readonly GenericRepository<T> _repository;

        public EFGenericDal(CategoryDbContext context, GenericRepository<T> repository)
        {
            _context = context;
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<T> GetListAll()
        {
            return _repository.GetListAll();
        }

        public void Insert(T entity)
        {
            _repository.Insert(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}

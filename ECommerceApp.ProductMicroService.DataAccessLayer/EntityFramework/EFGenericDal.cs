using ECommerceApp.ProductMicroService.DataAccessLayer.Abstract;
using ECommerceApp.ProductMicroService.DataAccessLayer.Context;
using ECommerceApp.ProductMicroService.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ProductMicroService.DataAccessLayer.EntityFramework
{
    public class EFGenericDal<T> : IGenericDal<T> where T : class
    {
        private readonly ProductDbContext _context;
        private readonly GenericRepository<T> _repository;

        public EFGenericDal(ProductDbContext context, GenericRepository<T> repository)
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

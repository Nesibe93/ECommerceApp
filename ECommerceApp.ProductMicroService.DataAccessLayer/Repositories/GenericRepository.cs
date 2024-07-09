using ECommerceApp.ProductMicroService.DataAccessLayer.Abstract;
using ECommerceApp.ProductMicroService.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.ProductMicroService.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ProductDbContext _context;

        public GenericRepository(ProductDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var values = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(values);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}

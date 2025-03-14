using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity
    {
        private readonly BookStoreContext _context;

        public GenericRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(_context.Set<T>().Find(id));
            _context.SaveChanges();
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}

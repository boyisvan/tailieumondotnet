using eShopOnWeb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopOnWeb.Repository
{
   public class GennericRepository<T>: IGenericRepository<T> where T:class
    {
        private readonly ShopOnlineContext _context;
        private readonly DbSet<T> _entities;
        public GennericRepository(ShopOnlineContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return _entities.Find(id);
        }
        public void Insert(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            T entity = GetById(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}

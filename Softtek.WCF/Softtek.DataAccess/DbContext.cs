using Microsoft.EntityFrameworkCore;
using Softtek.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Softtek.DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class,IEntity
    {
        DbSet<T> _items;
        ApiDbContext _ctx;

        public DbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items = ctx.Set<T>();
        }
        public void Delete(int id)
        {
            _items.Remove(GetById(id));
            _ctx.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Where(i => i.Id.Equals(i)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            _items.Add(entity);
            _ctx.SaveChanges();

            return entity;
        }
    }
}

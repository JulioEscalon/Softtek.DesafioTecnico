using Softtek.Abstraction;
using System;
using System.Collections.Generic;

namespace Softtek.Repository
{
    public interface IRepository<T> : ICrud<T>
    {

    }
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        IDbContext<T> _dbCtx;
        public Repository(IDbContext<T> dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public void Delete(int id)
        {
            _dbCtx.Delete(id);
        }

        public T GetById(int id)
        {
            return _dbCtx.GetById(id);
        }

        public IList<T> GetAll()
        {
            return _dbCtx.GetAll();
        }

        public T Save(T entity)
        {
            return _dbCtx.Save(entity);
        }
    }
}

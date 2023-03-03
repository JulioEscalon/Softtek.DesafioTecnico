using Softtek.ControlVentas.Abstraction;
using Softtek.ControlVentas.Repository;
using System;
using System.Collections.Generic;

namespace Softtek.ControlVentas.Application
{
    public interface IApplication<T> : ICrud<T>
    {

    }
    public class Application<T> : IApplication<T>
    {
        IRepository<T> _repository;
        public Application(IRepository<T> repository) 
        { 
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }
    }
}

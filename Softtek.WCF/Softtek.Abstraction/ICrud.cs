using System;
using System.Collections.Generic;

namespace Softtek.Abstraction
{
    public interface ICrud<T>
    {
        T Save(T entity);
        IList<T> GetAll();
        T GetById(int id);
        void Delete(int id);
    }
}

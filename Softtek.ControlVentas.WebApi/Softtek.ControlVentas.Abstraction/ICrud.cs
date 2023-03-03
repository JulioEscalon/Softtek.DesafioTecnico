using System;
using System.Collections;
using System.Collections.Generic;

namespace Softtek.ControlVentas.Abstraction
{
    public interface ICrud<T>
    {
        T Save(T entity);
        IList<T> GetAll();
        T GetByID(int id);
        void Delete(int id);

    }
}

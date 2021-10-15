using System;
using System.Collections.Generic;
using System.Text;

namespace Week4_EsFinale_Dal_Savio.Core
{
    public interface IRepository<T>
    {
        List<T> FetchAll();
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);
    }
}

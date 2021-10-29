using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Fetch(Func<T, bool> filter = null);
        T GetById(int id);
        bool AddItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(int id);
    }
}

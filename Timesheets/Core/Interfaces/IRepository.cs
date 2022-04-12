using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int Id);
        void Create(T item);
        void Update(int id);
        void Delete(int id);
    }
}

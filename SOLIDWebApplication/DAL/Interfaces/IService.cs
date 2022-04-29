using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLIDWebApplication.DAL.Interfaces
{
    public interface IService<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int Id);
        T SerachByTerm(string Term);
        IList<T> GetByPaging(int skip, int take);
    }
}

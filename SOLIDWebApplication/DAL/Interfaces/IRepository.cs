﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLIDWebApplication.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyList<T> GetAll();
        T GetById(int Id);
        T SerachByTerm(string Term);
        IReadOnlyList<T> GetByPaging(int skip, int take);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}

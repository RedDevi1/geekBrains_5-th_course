using System;
using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOLIDWebApplication.Models;

namespace SOLIDWebApplication.DAL.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        void IRepository<Person>.Create(Person item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Person>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IList<Person> IRepository<Person>.GetAll()
        {
            throw new NotImplementedException();
        }

        Person IRepository<Person>.GetById(int Id)
        {
            throw new NotImplementedException();
        }

        IList<Person> IRepository<Person>.GetByPaging(int skip, int take)
        {
            throw new NotImplementedException();
        }

        Person IRepository<Person>.SerachByTerm(string Term)
        {
            throw new NotImplementedException();
        }

        void IRepository<Person>.Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}

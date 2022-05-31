using System;
using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOLIDWebApplication.Models;

namespace SOLIDWebApplication.DAL.Repositories
{
    internal sealed class PersonsRepository : IPersonsRepository
    {
        private readonly PersonDbContext _context;
        public PersonsRepository(PersonDbContext context)
        {
            _context = context;
        }
        //public bool Create(Person entity)
        //{
        //    try
        //    {
        //        _context.Add(entity);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public bool Delete(int id)
        {
            Person entity = _context.Persons.Find(id);
            entity.IsDeleted = true;
            return Commit();
        }

        public IReadOnlyList<Person> GetAll()
        {
            return _context.Persons.Where(x => x.IsDeleted == false).ToList();
        }

        public Person GetById(int Id)
        {
            return _context.Persons.Find(Id);
        }

        public IReadOnlyList<Person> GetByPaging(int skip, int take)
        {
            return _context.Persons.Where(x => x.IsDeleted == false).Skip<Person>(skip).Take<Person>(take).ToList();
        }

        public Person SerachByTerm(string Term)
        {
            throw new NotImplementedException();
        }

        //public bool Update(Person entity)
        //{
        //    return Commit();
        //}

        private bool Commit()
        {
            int count = _context.SaveChanges();
            return count > 0;
        }
    }
}

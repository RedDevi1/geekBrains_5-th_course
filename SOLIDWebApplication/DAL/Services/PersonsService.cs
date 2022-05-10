using System;
using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOLIDWebApplication.Models;
using AutoMapper;

namespace SOLIDWebApplication.DAL.Services
{
    public class PersonsService : IPersonsService
    {
        private IPersonsRepository repository;
        private readonly IMapper mapper;
        public PersonsService(IPersonsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public IReadOnlyList<PersonDTO> GetAll()
        {
            IReadOnlyList<Person> persons = repository.GetAll();
            var personsDTOList = new List<PersonDTO>();
            foreach(var person in persons)
            {
                personsDTOList.Add(mapper.Map<PersonDTO>(person));
            }
            return personsDTOList;
        }

        public PersonDTO GetById(int Id)
        {
            Person person = repository.GetById(Id);
            var personsDTO = mapper.Map<PersonDTO>(person);
            return personsDTO;
        }

        public PersonDTO SerachByTerm(string Term)
        {
            Person person = repository.SerachByTerm(Term);
            var personsDTO = mapper.Map<PersonDTO>(person);
            return personsDTO;
        }

        public IReadOnlyList<PersonDTO> GetByPaging(int skip, int take)
        {
            IReadOnlyList<Person> persons = repository.GetAll();
            var personsDTOList = new List<PersonDTO>();
            foreach (var person in persons)
            {
                personsDTOList.Add(mapper.Map<PersonDTO>(person));
            }
            return personsDTOList;
        }
    }
}

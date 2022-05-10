using System;
using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOLIDWebApplication.Models;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace SOLIDWebApplication.DAL.Services
{
    public class PersonsService : IPersonsService
    {
        private IPersonsRepository repository;
        private readonly IMapper mapper;
        public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da badee";
        private IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"test", "test"}
        };
        public PersonsService(IPersonsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public string Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) ||
            string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }
            int i = 0;
            foreach (KeyValuePair<string, string> pair in _users)
            {
                i++;
                if (string.CompareOrdinal(pair.Key, user) == 0 &&
                string.CompareOrdinal(pair.Value, password) == 0)
                {
                    return GenerateJwtToken(i);
                }
            }
            return string.Empty;
        }

        private string GenerateJwtToken(int id)
        {
            JwtSecurityTokenHandler tokenHandler = new
            JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);
            SecurityTokenDescriptor tokenDescriptor = new
            SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IReadOnlyList<PersonDTO> GetAll()
        {
            IReadOnlyList<Person> persons = repository.GetAll();
            var personsDTOList = new List<PersonDTO>();
            foreach (var person in persons)
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

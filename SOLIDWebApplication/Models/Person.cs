using System;
using SOLIDWebApplication.DAL.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOLIDWebApplication.Models
{
    [Table("Person", Schema = "Test")]
    public sealed class Person : BaseEntity<int>
    {
        private readonly PersonsRepository repository;

        public Person (PersonsRepository repository)
        {
            this.repository = repository;
        }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Company")]
        public string Company { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        public void Create (Person person)
        {          
            try
            {
               repository.Create (person);
            }
            catch (Exception exception)
            {
                throw new Exception (exception.Message);
            }
        }

        public void Update(Person person)
        {
            try
            {
                repository.Update (person);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

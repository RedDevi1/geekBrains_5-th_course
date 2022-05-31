using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOLIDWebApplication.Models
{
    [Table("Person", Schema = "Test")]
    public sealed class Person : BaseEntity<int>
    {
        private PersonDbContext Context { get; set; }

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
                Context.Add(person);
                Context.SaveChanges();
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
                Context.Update(person);
                Context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

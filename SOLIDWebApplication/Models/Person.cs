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
        //[Column("FirstName")]
        public string FirstName { get; set; }

        //[Column("LastName")]
        public string LastName { get; set; }

        //[Column("Email")]
        public string Email { get; set; }

        //[Column("Company")]
        public string Company { get; set; }

        //[Column("Age")]
        public int Age { get; set; }
    }
}

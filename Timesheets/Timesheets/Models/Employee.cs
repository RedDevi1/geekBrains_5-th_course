using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Employee
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Patronymic { set; get; }
        public int Id { set; get; }
        public int ContractsId { set; get; }
    }
}

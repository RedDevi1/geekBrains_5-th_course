using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ContractsId { get; set; }
        public double Price { get; set; }
    }
}

using System;
using SOLIDWebApplication.Models;
using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLIDWebApplication.DAL.Interfaces
{
    public interface IPersonsService : IService<PersonDTO>
    {
    }
}

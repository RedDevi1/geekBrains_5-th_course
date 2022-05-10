using System;
using SOLIDWebApplication.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace SOLIDWebApplication.DAL.Interfaces
{
    public interface IPersonsService : IService<PersonDTO>
    {
        TokenResponse Authenticate(string user, string password);
    }
}

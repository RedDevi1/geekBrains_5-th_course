using System;
using SOLIDWebApplication.Models;
using SOLIDWebApplication.DAL.Responses;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SOLIDWebApplication.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLIDWebApplication.DAL.Interfaces
{
    public interface IPersonsService : IService<PersonDTO>
    {
        bool IsUserNameAlreadyExist(string firstName);
        TokenResponse Authenticate(string user, string password);
        string RefreshToken(string token);
    }
}

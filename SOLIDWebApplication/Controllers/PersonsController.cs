using Microsoft.AspNetCore.Http;
using SOLIDWebApplication.DAL.Responses;
using SOLIDWebApplication.DAL.Services;
using SOLIDWebApplication.DAL.Interfaces;
using SOLIDWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace SOLIDWebApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PersonsController : ControllerBase
    {
        private readonly IPersonsRepository repository;
        private readonly IPersonsService personsService;
        private readonly IMapper mapper;
        private readonly IPersonValidationService validationService;
        public PersonsController(IPersonsRepository repository, IPersonsService personsService, IMapper mapper, IPersonValidationService validationService)
        {
            this.personsService = personsService;
            this.repository = repository;
            this.mapper = mapper;
            this.validationService = validationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            TokenResponse token = personsService.Authenticate(user, password);
            if (token is null)
            {
                return BadRequest(new
                {
                    message = "Username or password is incorrect"
                });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            string newRefreshToken = personsService.RefreshToken(oldRefreshToken);

            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);
            return Ok(newRefreshToken);
        }
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }


        [HttpPost("add")]
        public bool Create([FromBody] Person person)
        {
            IReadOnlyList<IOperationFailure> failures = validationService.ValidateEntity(person);
            if (failures.Count == 0)
            {
                var result = repository.Create(person);
                return result;
            }
            return false;
        }

        [HttpPut("update")]
        public bool Update([FromBody] Person person)
        {
            var result = repository.Update(person);
            return result;
        }

        [HttpDelete("delete/{id}")]
        public bool Delete([FromRoute] int id)
        {
            var result = repository.Delete(id);
            return result;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var allPersons = personsService.GetAll();
            var personsResponse = new PersonsResponse();
            var response = new List<PersonsResponse>();
            foreach (var person in allPersons)
            {
                personsResponse.PersonControllerDTO = mapper.Map<PersonControllerDTO>(person);
                response.Add(personsResponse);
            }
            return Ok(response);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var person = personsService.GetById(id);
            var response = new PersonsResponse
            {
                PersonControllerDTO = mapper.Map<PersonControllerDTO>(person)
            };
            return Ok(response);
        }

        [HttpGet("search/{term}")]
        public IActionResult SearchByTerm([FromRoute] string term)
        {
            var person = personsService.SerachByTerm(term);
            var response = new PersonsResponse
            {
                PersonControllerDTO = mapper.Map<PersonControllerDTO>(person)
            };
            return Ok(response);
        }

        [HttpGet("skip/{skip}/take/{take}")]
        public IActionResult GetByPaging([FromRoute] int skip, [FromRoute] int take)
        {
            var persons = personsService.GetByPaging(skip, take);
            var personsResponse = new PersonsResponse();
            var response = new List<PersonsResponse>();
            foreach (var person in persons)
            {
                personsResponse.PersonControllerDTO = mapper.Map<PersonControllerDTO>(person);
                response.Add(personsResponse);
            }
            return Ok(response);
        }
    }
}

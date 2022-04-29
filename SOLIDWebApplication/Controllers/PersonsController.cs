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

namespace SOLIDWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonsRepository repository;
        private IPersonsService personsService;
        private readonly IMapper mapper;
        public PersonsController(IPersonsRepository repository, IPersonsService personsService, IMapper mapper)
        {
            this.personsService = personsService;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Create([FromBody] Person person)
        {
            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult Update([FromRoute] int id)
        {
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok();
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

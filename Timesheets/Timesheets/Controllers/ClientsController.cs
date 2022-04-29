using Microsoft.AspNetCore.Http;
using Timesheets.DAL.Repositories;
using Timesheets.DAL.Interfaces;
using Timesheets.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClientsRepository repository;

        public ClientsController (IClientsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("register")]
        public IActionResult Create([FromBody] Contract contract)
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
            return Ok();
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok();
        }
    }
}

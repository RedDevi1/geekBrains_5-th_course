using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheets.DAL.Interfaces;
using Timesheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private IInvoicesRepository repository;

        public InvoicesController(IInvoicesRepository repository)
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

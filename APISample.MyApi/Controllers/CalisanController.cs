using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalisanController : ControllerBase
    {

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }

        //[HttpGet("~/getAll/{i}")]
        [HttpGet("{i}")]
        public IActionResult Get(int i)
        {
            return Ok();
        }

        [HttpPost("~/calisanEkle")]
        public IActionResult PostEmployee()
        {
            return Ok();
            return BadRequest();
            return NoContent();
            return NotFound();

            return new StatusCodeResult(201);
        }
    }
}

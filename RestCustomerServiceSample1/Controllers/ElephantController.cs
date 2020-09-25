using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestCustomerServiceSample1.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestCustomerServiceSample1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ElephantController : ControllerBase
    {
        private List<Elephants> _dbList;
        public ElephantController()
        {
            _dbList = FakeDbList.elephants;
        }
        // GET: api/<ElephantController>
        [HttpGet]
        public List<Elephants> Get()
        {
            return _dbList;
        }

        // GET api/<ElephantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var elephant = GetElephant(id);
            if(elephant == null)
            {                
                return NotFound( new {message ="Id not found"});
            }
            return Ok(elephant);
        }

        // POST api/<ElephantController>
        [HttpPost]
        public IActionResult Post([FromBody] Elephants elephant)
        {
            if(!ElephantExists(elephant.Id))
            {
                _dbList.Add(elephant);
                return CreatedAtAction("Get", new { id = elephant.Id }, elephant);
            }
            else
            {
                return NotFound(new { message = "Id is duplicate" });
            }
        }

        // PUT api/<ElephantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Elephants newElephant)
        {
            if(id != newElephant.Id)
            {
                return BadRequest();
            }
            var currentElephant = GetElephant(id);

            if(currentElephant != null)
            {
                currentElephant.Name = newElephant.Name;
                currentElephant.Species = newElephant.Species;
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<ElephantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {           
            var elephant = GetElephant(id);

            if (elephant != null)
            {
                _dbList.Remove(elephant);
            }
            else
            {
                return NotFound();
            }
            return Ok(elephant);
        }

        public Elephants GetElephant(int id)
        {
            var elephant = _dbList.FirstOrDefault(e => e.Id == id);
            return elephant;
        }
        private bool ElephantExists(long id)
        {
            return _dbList.Any(e => e.Id == id);
        }
    }
}

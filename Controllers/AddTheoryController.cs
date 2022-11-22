using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTheoryController : ControllerBase
    {
        lsscPortalContext _db = new lsscPortalContext();
        // GET: api/<AddTheoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddTheoryController>/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddTheoryController>
        [HttpPost]
        public async Task Post([FromBody] List<TblTheoryQuestions> theory)
        {
            try
            {
                foreach (TblTheoryQuestions items in theory)
                {
                    await _db.TblTheoryQuestions.AddAsync(items);
                    await _db.SaveChangesAsync();

                }
            }
            catch(Exception e)
            {
                Console.Write(e);
            }

        }

        // PUT api/<AddTheoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddTheoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

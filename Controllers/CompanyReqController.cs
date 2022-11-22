using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyReqController : ControllerBase
    {
        lsscPortalContext _db = new lsscPortalContext();
        // GET: api/CompanyReq
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CompanyReq/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CompanyReq
        [HttpPost]
        public async Task Post([FromBody] TblCompanyRequirment comp)
        {
            await _db.TblCompanyRequirment.AddAsync(comp);
            await _db.SaveChangesAsync();
        }


        // PUT: api/CompanyReq/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

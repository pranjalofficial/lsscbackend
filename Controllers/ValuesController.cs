using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        lsscPortalContext _db = new lsscPortalContext();

        // GET api/values
        [HttpGet]
        public IEnumerable<projectData> Get()
        {
            return _db.projectData.FromSql("exec spProjectData").ToList<projectData>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<TblAssessmentBatch> Get(int id)
        {
            TblAssessmentBatch asm;
            asm = await _db.TblAssessmentBatch.Where(i => i.AsId == id).FirstOrDefaultAsync<TblAssessmentBatch>();
            return asm;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] List<TblPracticalQuestion> practical)
        {
            try
            {
                foreach (TblPracticalQuestion item in practical)
                {
                    await _db.TblPracticalQuestion.AddAsync(item);
                    await _db.SaveChangesAsync();

                }

            }
            catch (Exception)
            {

            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

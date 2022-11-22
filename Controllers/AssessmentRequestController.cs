using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AssessmentRequestController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/AssessmentRequest
        [HttpGet]
        public IEnumerable<TblAssessmentBatch> Get()
        {
            return dataOut.TblAssessmentBatch.OrderByDescending(x => x.AsId).ToList();
        }

        // GET: api/AssessmentRequest/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<TblTheoryQuestions>> Get(string id, [FromBody] string lang)
        {
            List<TblTheoryQuestions> theory;
            theory = await (dataOut.TblTheoryQuestions.FromSql("exec spLangRelTheoryQue '"+id+"','"+lang+"'").ToListAsync<TblTheoryQuestions>());
            return theory;
        }

        // POST: api/AssessmentRequest
        [HttpPost("RequestID")]
        public int Post([FromBody] TblAssessmentBatch assessment)
        {
            dataOut.TblAssessmentBatch.Add(assessment);
            dataOut.SaveChanges();
            var latestRequestId = dataOut.TblAssessmentBatch
                       .OrderByDescending(p => p.AsId)
                       .FirstOrDefault();
            return latestRequestId.AsId;
        }

    }
}

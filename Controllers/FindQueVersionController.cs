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
    public class FindQueVersionController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/FindQueVersion
        [HttpPut]
        public IEnumerable<TblQuestionPaperVersion> Put(TblQuestionBank id)
        {
            return dataOut.TblQuestionPaperVersion.Where(s => s.QvQbcode == id.QbQuestionCode).ToList<TblQuestionPaperVersion>();
        }

        //[HttpGet("id")]
        //public async Task<>

        
    }
}

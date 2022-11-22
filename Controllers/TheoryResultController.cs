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
    [ApiController]
    public class TheoryResultController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();

        // POST: api/TheoryResult
        [HttpPost]
        public void Post([FromBody] TblTheoryResult thResult)
        {

            //var res = dataOut.Database.ExecuteSqlCommand("exec spTheoryResult "+thResult.TrbatchId+", '"+thResult.TrCandidateId+"' ,"+ thResult.TrMarks1+"," + thResult.TrMarks2 + "," + thResult.TrMarks3 + "," + thResult.TrMarks4 + "," + thResult.TrMarks5 + "," + thResult.TrMarks6 + "," + thResult.TrMarks7 + "," + thResult.TrMarks8 + "," + thResult.TrMarks9 + "," + thResult.TrMarks10 + "," + thResult.TrMarks11 + "," + thResult.TrMarks12 + "," + thResult.TrMarks13 + "," + thResult.TrMarks14 + "," + thResult.TrMarks15 + "," + thResult.TrMarks16 + "," + thResult.TrMarks17 + "," + thResult.TrMarks18 + "," + thResult.TrMarks19 + "," + thResult.TrMarks20 + ","+ thResult.TrTotalMarks);
            try
            {
                dataOut.TblTheoryResult.Add(thResult);
                dataOut.SaveChanges();
                dataOut.Database.ExecuteSqlCommand("exec spTheoryBitChange '" + thResult.TrCandidateId + "'");
            }
            catch (Exception)
            {

            }

        }

        [HttpGet("{id}")]
        public IQueryable<TblTheoryResult>  Get(int id)
        {
            var result = dataOut.TblTheoryResult.Where(i => i.TrbatchId == id);
            return result;
        }




    }
}
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
    public class PracticalResultController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();

        [HttpGet("{id}")]
        public async Task<IEnumerable<TblPracticalResult>> Get(int id)
        {
            var result =await dataOut.TblPracticalResult.Where(i => i.PrbatchId == id).ToListAsync();
            return  result;
        }
        [HttpPost]
        public async Task Post([FromBody] List<TblPracticalResult> prResult)
        {
            foreach (TblPracticalResult item in prResult)
            {
                if (item.PrCandidateId != null)
                {
                    await dataOut.TblPracticalResult.AddAsync(item);
                    await dataOut.SaveChangesAsync();
                    if(item.PrType == false)
                    {
                        dataOut.Database.ExecuteSqlCommand("exec spPracticalBitChange '" + prResult.First().PrCandidateId + "'");
                    }
                    else
                    {
                        dataOut.Database.ExecuteSqlCommand("exec spTheoryBitChange '" + prResult.First().PrCandidateId + "'");
                    }
                }
                else
                {
                    break;
                }
            }

                //TblFinalResult final = null;
                //dataOut.Database.ExecuteSqlCommand("exec spPracticalBitChange '" + prResult.First().PrCandidate + "'");
                //TblTheoryResult cand = dataOut.TblTheoryResult.Where(s => s.TrCandidateId == prResult.First().PrCandidateId).First();
                //final.FrbatchId = cand.TrbatchId;
                //final.FrCandidateId = cand.TrCandidateId;
                //final.FrPracticalId = prResult.First().PrId;
                //final.FrPracticalResult = tmarks;
                //final.FrTheoryId = cand.TrId;
                //final.FrTheoryResult = cand.TrTotalMarks;
                //final.FrFinalResult = final.FrTheoryResult + final.FrPracticalResult;
                //dataOut.TblFinalResult.Add(final);
                //dataOut.SaveChanges();
            }
    }
}
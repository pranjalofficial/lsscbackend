using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    
    public class CandidateAddController : ControllerBase
    {
        lsscPortalContext _db = new lsscPortalContext();

        // POST: api/CandidateAdd
        [HttpPost("AddCandidate")]
        public async Task Post([FromBody] List<TblCandidateList> candList)
        {
            try
            {
                foreach (TblCandidateList item in candList)
                {
                    await _db.TblCandidateList.AddAsync(item);
                    await _db.SaveChangesAsync();

                }

            }
            catch (Exception)
            {

            }

        }

        // PUT: api/CandidateAdd/5
    }
}

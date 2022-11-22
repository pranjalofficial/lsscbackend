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
    public class CandidateListController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/CandidateList
        [HttpGet("{id}")]
        public async Task<IEnumerable<TblCandidateList>> Get(int id)
        {
            List<TblCandidateList> candidateList;
            candidateList = await (dataOut.TblCandidateList.FromSql("exec spCandidateList " + id).ToListAsync<TblCandidateList>());
            return candidateList;
        }
    }
}
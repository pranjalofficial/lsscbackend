using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ViewQpController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/ViewQp
        [HttpGet]
        public async Task<IEnumerable<TblQp>> Get()
        {
            return await (dataOut.TblQp.ToListAsync<TblQp>());
        }

        // GET: api/ViewQp/5
        [HttpPut]
        public IEnumerable<TblQuestionBank> Put([FromBody] TblQp id)
        {
            var query = dataOut.TblQuestionBank.Where(s => s.QbRelatedQp == id.QpCode).ToList<TblQuestionBank>();
            return query;
        }

        [HttpPost]
        public TblQuestionBank Post([FromBody] TblQuestionBank qb)
        {
            //dataOut.TblQuestionBank.Add(qb);
            //dataOut.SaveChanges();
            dataOut.Database.ExecuteSqlCommand("exec addQB '"+qb.QbName+"','"+qb.QbRelatedQp+"'");

            TblQuestionBank addedQB = dataOut.TblQuestionBank.Where(i => i.QbRelatedQp == qb.QbRelatedQp && i.QbName == qb.QbName).FirstOrDefault();

            return addedQB;
        }

    }
}

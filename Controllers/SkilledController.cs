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
    public class SkilledController : ControllerBase
    {
        lsscPortalContext _db = new lsscPortalContext();
        // GET: api/Skilled
        //[HttpGet]
        //public async Task<TblCandidateList> Get()
        //{
        //    TblCandidateList cand;
        //    cand = await _db.TblCandidateList.Where(i => i.ClEnrollmentNo == "262126224322").SingleOrDefaultAsync<TblCandidateList>();
        //    return cand;
        //}

        //[route("api/[controller]")]
        // GET: api/Skilled/5
        [HttpGet("{id}")]
        public async Task<TblCandidateList> Get(string id)
        {

            TblCandidateList cand = null;
            try
            {
                //lang = "Tamil";
                //cand = await (_db.TblCandidateList.FromSql("exec getCandidateRPL5 " + id + ",'" + candId + "'").SingleAsync<TblCandidateList>());
                cand = await _db.TblCandidateList.Where(i => i.ClEnrollmentNo == id).SingleOrDefaultAsync<TblCandidateList>();
                return cand;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return cand;
            }
        }

        // POST: api/Skilled
        [HttpPost]
        public async Task Post([FromBody] SkilledPerson skill)
        {
            await _db.SkilledPerson.AddAsync(skill);
            await _db.SaveChangesAsync();


        }

        // PUT: api/Skilled/5
        [HttpPut]
        public void Put([FromBody] Image img)
        {
            var latestRequestId = _db.SkilledPerson
          .OrderByDescending(p => p)
          .FirstOrDefault();
            latestRequestId.SpImage = img.selectedFile;
            _db.Entry(latestRequestId).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

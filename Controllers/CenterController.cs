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
    public class CenterController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/Center
        [HttpGet]
        public IEnumerable<TblCenter> Get()
        {
            return dataOut.TblCenter.OrderByDescending(a => a.CenterName).ToList();
        }


        // POST: api/Center
        [HttpPost]
        public async Task Post([FromBody] TblCenter center)
        {
            try
            {
                await dataOut.TblCenter.AddAsync(center);
                await dataOut.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }
    }
}

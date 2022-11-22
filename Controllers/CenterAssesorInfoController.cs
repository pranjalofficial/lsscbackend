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
    public class CenterAssesorInfoController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/CenterAssesorInfo/5
        [HttpGet("{id}")]
        [Route("api/CenterAssesorInfo")]
        public async Task<CenterAssesorInfo> Get(int id)
        {
            CenterAssesorInfo ca;
            try
            {
                ca = await (dataOut.CenterAssesors.FromSql("exec spCenterAssesor " + id).SingleOrDefaultAsync<CenterAssesorInfo>());
            }
            catch (Exception)
            {
                return null;
            }
            return ca;
        }
    }
}
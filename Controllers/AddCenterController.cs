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
    public class AddCenterController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        
        [HttpPost("AddCenter")]
        public void Post([FromBody] TblCenter center)
        {
            try
            {
                dataOut.TblCenter.Add(center);
                dataOut.SaveChanges();
            }
            catch (Exception)
            {

            }

        }
    }
}
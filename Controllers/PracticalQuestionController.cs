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
    public class PracticalQuestionController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/PracticalQuestions
        [HttpGet("{id}")]
        public async Task<IEnumerable<TblPracticalQuestion>> Get(int id)
        {
            List<TblPracticalQuestion> practicalQuestion;
            practicalQuestion = await (dataOut.TblPracticalQuestion.FromSql("exec spQuestionPaperPractical " + id).ToListAsync<TblPracticalQuestion>());
            return practicalQuestion;
        }
    }
}
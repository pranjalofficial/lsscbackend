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
    public class TheoryQuestionController : ControllerBase
    {
        lsscPortalContext dataOut = new lsscPortalContext();
        // GET: api/QuestionPaper
        [HttpGet("{id}")]
        public async Task<IEnumerable<TblTheoryQuestions>> Get(int id)
        {
            List<TblTheoryQuestions> theoryQue;
            theoryQue = await (dataOut.TblTheoryQuestions.FromSql("exec spQuestionPaperTheory " + id).ToListAsync<TblTheoryQuestions>());
            return theoryQue;
        }
    }
}
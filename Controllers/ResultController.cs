using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Spire.Xls;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ResultController : ControllerBase
    {
        lsscPortalContext _db = new lsscPortalContext();
        // GET: api/Result
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET: api/Result/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            string nameID = id.ToString();
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = nameID +".xlsx";
            int i = 0;
            int j = 0;
            int k = 2;
            int a = 0;
            List<TblCandidateList> cand = new List<TblCandidateList>();
            List<TblPracticalResult> res = new List<TblPracticalResult>();
            List<string> nosTheory = new List<string>();
            List<string> nosPractical = new List<string>();
            List<int> theoryMarks = new List<int>();
            List<int> practicalMarks = new List<int>();
            int theoryTotal = 0;
            int practicalTotal = 0;
            int total = 0;

            cand = _db.TblCandidateList.FromSql("exec spGetCandidates " + id).ToList<TblCandidateList>();
            //cand = _db.TblCandidateList.Where(l => l.ClReqNo == id).ToList<TblCandidateList>();
            res = _db.TblPracticalResult.FromSql("exec spResultById "+ id).ToList<TblPracticalResult>();
            //res = _db.TblPracticalResult.Where(s => s.PrbatchId == id).ToList<TblPracticalResult>();
            
            nosTheory = _db.TblPracticalResult.Where(s => s.PrbatchId == id && s.PrType == true)
                .Select(d=>d.PrNos)
                .Distinct()
                .OrderBy(d => d)
                .AsEnumerable()
                .ToList();

            nosPractical = _db.TblPracticalResult.Where(s => s.PrbatchId == id && s.PrType == false)
                .Select(d => d.PrNos)
                .Distinct()
                .OrderBy(d => d)
                .AsEnumerable()
                .ToList();

            string questionVersion = _db.TblAssessmentBatch.Where(s => s.AsId == id).Select(s => s.AsQuestionVersion).FirstOrDefault();

            practicalMarks = _db.TblPracticalQuestion.Where(s => s.PqVersionOfQb == questionVersion && s.PqLang == "English")
                .Select(d => d.PqMarks)
                .ToList();

            theoryMarks = _db.TblTheoryQuestions.Where(s => s.TqVersionOfQb == questionVersion && s.TqLanguage == "English")
                .Select(d => d.TqMarks)
                .ToList();

            for(int index = 0; index < theoryMarks.Count; index++)
            {
                theoryTotal += theoryMarks[index];
            }

            for (int index = 0; index < practicalMarks.Count; index++)
            {
                practicalTotal += practicalMarks[index];
            }

            total = theoryTotal + practicalTotal;

            int length = nosTheory.Count + nosPractical.Count + 2;
            int theorySum = 0;
            int practicalSum = 0;
            int sum = 0;
            float percentage =0;
            var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add(id);

            worksheet.Cell(1, 1).Value = "Enrollment No";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 2).Style.Font.Bold = true;
            worksheet.Cell(1, length + 1).Value = "Theory Total(MM: " + theoryTotal +")";
            worksheet.Cell(1, length + 2).Value = "Practical Total(MM: " + practicalTotal + ")";
            worksheet.Cell(1, length + 3).Value = "Total(MM: " + total + ")";
            worksheet.Cell(1, length + 4).Value = "Candidate %";
            worksheet.Cell(1, length + 5).Value = "Result";
            worksheet.Cell(1, length + 1).Style.Font.Bold = true;
            worksheet.Cell(1, length + 2).Style.Font.Bold = true;
            worksheet.Cell(1, length + 3).Style.Font.Bold = true;
            worksheet.Cell(1, length + 4).Style.Font.Bold = true;
            worksheet.Cell(1, length + 5).Style.Font.Bold = true;
            worksheet.Cell(1, length + 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#FD1C17");
            worksheet.Cell(1, length + 2).Style.Fill.BackgroundColor = XLColor.FromHtml("#FD1C17");
            worksheet.Cell(1, length + 3).Style.Fill.BackgroundColor = XLColor.FromHtml("#FD1C17");
            worksheet.Cell(1, length + 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#FD1C17");
            worksheet.Cell(1, length + 5).Style.Fill.BackgroundColor = XLColor.FromHtml("#FD1C17");


            for (int index = 3; index <=3 + nosTheory.Count - 1;index++) 
            {
                string tempStr = _db.TblNos.Where(o => o.NosCode == nosTheory[i]).Select(d => d.NosName).FirstOrDefault();
                worksheet.Cell(1, index).Value = "Section " + (i + 1) + ": " + tempStr + " (" + nosTheory[i] + ")";
                worksheet.Cell(1, index).Style.Font.Bold = true;
                worksheet.Cell(1, index).Style.Fill.BackgroundColor = XLColor.FromHtml("#8904C7");
                i++;
                tempStr = null;
            }
            for (int index = 3 + nosTheory.Count; index <= 3 + nosTheory.Count + nosPractical.Count - 1; index++)
            {
                string tempStrPr = _db.TblNos.Where(o => o.NosCode == nosPractical[j]).Select(d => d.NosName).FirstOrDefault();
                worksheet.Cell(1, index).Value = "Section " + (j + 1) + ": " + tempStrPr + " (" + nosPractical[j] + ")";
                worksheet.Cell(1, index).Style.Font.Bold = true;
                worksheet.Cell(1, index).Style.Fill.BackgroundColor = XLColor.FromHtml("#8904C7");
                j++;
                tempStrPr = null;
            }

            for (int index = 0; index <= cand.Count-1; index++)
            {
                worksheet.Cell(k, 1).Value = cand[index].ClEnrollmentNo;
                worksheet.Cell(k, 2).Value = cand[index].ClName;
                k++;
            }

            List<TblPracticalResult> resTemp = new List<TblPracticalResult>();
            List<TblPracticalResult> r = new List<TblPracticalResult>();
            
            for (int temp = 2; temp <= cand.Count + 1; temp++)
            {
               string tempString = worksheet.Cell(temp, 1).Value.ToString();
               resTemp = res.Where(s => s.PrCandidateId == tempString).ToList<TblPracticalResult>();
               foreach (TblPracticalResult item in resTemp)
               {
                    i = 0;
                    if(item.PrType == true)
                    {
                        do
                        {
                            if (String.Equals(nosTheory[i], item.PrNos))
                            {
                                if(item.PrMarks > item.PrQuestionId)
                                {
                                    int? t = item.PrQuestionId - 5;
                                    worksheet.Cell(temp, 3 + i).Value = t;
                                }
                                else
                                {
                                    worksheet.Cell(temp, 3 + i).Value = item.PrMarks;
                                }
                            }
                            i++;
                        } while (i < nosTheory.Count);
                    }
                    else 
                    {
                        do
                        {
                            if (String.Equals(nosPractical[i], item.PrNos))
                            {
                                if (item.PrMarks > item.PrQuestionId)
                                {
                                    int? t = item.PrQuestionId - 10;
                                    worksheet.Cell(temp, nosTheory.Count + 3 + i).Value = t;
                                }
                                else
                                {
                                    worksheet.Cell(temp, nosTheory.Count + 3 + i).Value = item.PrMarks;
                                }
                            }
                            i++;
                        } while (i < nosPractical.Count);
                    }
                }
            }


            for (int index=2;index<=cand.Count+1;index++)
            {
                theorySum = 0;
                for (int z=3;z<=3+nosTheory.Count -1;z++)
                {
                    //int temp2 = 0;
                    if (!worksheet.Cell(index, z).IsEmpty())
                    {
                        //temp2 = (int)worksheet.Cell(index, z).Value;
                        theorySum += Int16.Parse(worksheet.Cell(index, z).Value.ToString());
                    }
                    else
                    {
                        theorySum += 0;
                    }

                }
                worksheet.Cell(index, length + 1).Value = theorySum;
            }

            for (int index = 2; index <= cand.Count + 1; index++)
            {
                practicalSum = 0;
                for (int z = 3+nosTheory.Count; z <= length; z++)
                {
                    if (!worksheet.Cell(index, z).IsEmpty())
                    {
                        practicalSum += Int16.Parse(worksheet.Cell(index,z).Value.ToString());
                    }
                    else
                    {
                        practicalSum += 0;
                    }
                }
                worksheet.Cell(index, length + 2).Value = practicalSum;
            }

            for (int index = 2; index <= cand.Count + 1; index++)
            {
                sum = 0;
                sum = Int16.Parse(worksheet.Cell(index, length+1).Value.ToString()) + Int16.Parse(worksheet.Cell(index, length + 2).Value.ToString());
                worksheet.Cell(index, length + 3).Value = sum;
            }

            for (int index = 2; index <= cand.Count + 1; index++)
            {
                percentage = 0;
                percentage = (float.Parse(worksheet.Cell(index, length + 3).Value.ToString()) / total) * 100;
                worksheet.Cell(index, length + 4).Value = percentage;
                if(percentage >= 70)
                {
                    worksheet.Cell(index, length + 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#67F594");
                    worksheet.Cell(index, length + 5).Value = "PASS";
                }
                else
                {
                    worksheet.Cell(index, length + 4).Style.Fill.BackgroundColor = XLColor.FromHtml("#E64D44");
                    worksheet.Cell(index, length + 5).Value = "FAIL";
                }
            }

            worksheet.Style.Alignment.WrapText = false;

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, contentType, fileName);
            }
        }

        // POST: api/Result
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Result/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

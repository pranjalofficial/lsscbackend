using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebApplication3.Models;
using System.Data;
using System.Net;
using System.Web;
using System.Web.Http;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AddCandidateController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        lsscPortalContext _db;

        public AddCandidateController(IHostingEnvironment hostingEnvironment, lsscPortalContext db)
        {
            _hostingEnvironment = hostingEnvironment;
            _db = db;
        }

        //[HttpGet]
        //public async Task<TblCandidateList> Get()
        //{
        //    TblCandidateList cand;
        //    //, [FromBody] string candId
        //    //lang = "Tamil";
        //    //cand = await (_db.TblCandidateList.FromSql("exec getCandidateRPL5 " + id + ",'" + candId + "'").SingleAsync<TblCandidateList>());
        //    cand = await _db.TblCandidateList.Where(i => i.ClEnrollmentNo == "262126224322").SingleOrDefaultAsync<TblCandidateList>();
        //    return cand;
        //}

        // GET api/AddCandidate/5
        //[HttpGet("{id}")]
        //public async Task<TblCandidateList> Get(string id, [FromBody] string candId)
        //{
        //    TblCandidateList cand;
        //    //lang = "Tamil";
        //    cand = await (_db.TblCandidateList.FromSql("exec getCandidateRPL5 " + id + ",'" + candId + "'").SingleAsync<TblCandidateList>());
        //    //cand = await _db.TblCandidateList.Where(i => i.ClEnrollmentNo == id).SingleOrDefaultAsync<TblCandidateList>();
        //    return cand;
        //}

        [HttpPost("UploadExcel")]
        public Boolean Post([FromBody] List<TblCandidateList> candList)
        {

            foreach (TblCandidateList item in candList)
            {
                _db.TblCandidateList.Add(item);
            }
            
            //Stream stream = files.OpenReadStream();
            //string message;
            //IExcelDataReader reader = null;
            //if (files.FileName.EndsWith(".xls"))
            //{
            //    reader = ExcelReaderFactory.CreateBinaryReader(stream);
            //}
            //else if (files.FileName.EndsWith(".xlsx"))
            //{
            //    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //}
            //else
            //{
            //    message = "This file format is not supported";
            //}

            //DataSet excelRecords = reader.AsDataSet();
            //reader.Close();

            //var finalRecords = excelRecords.Tables[0];
            //for (int i = 0; i < finalRecords.Rows.Count; i++)
            //{
            //    TblCandidateList objUser = new TblCandidateList();
            //    objUser.ClEnrollmentNo = finalRecords.Rows[i][0].ToString();
            //    objUser.ClName = finalRecords.Rows[i][1].ToString();
            //    objUser.ClReqNo = (Int32)finalRecords.Rows[i][2];
            //    objUser.ClTheoryDeone = (Boolean)finalRecords.Rows[i][3];
            //    objUser.ClPracticalDone = (Boolean)finalRecords.Rows[i][4];

            //    _db.TblCandidateList.Add(objUser);

            //}

            //int output = _db.SaveChanges();
            //if (output > 0)
            //{
            //    message = "Excel file has been successfully uploaded";
            //}
            //else
            //{
            //    message = "Excel file uploaded has fiald";
            //}




            //string message = "";
            //HttpResponseMessage result = null;
            //var httpRequest = HttpContext.Request;

            //if (httpRequest.Form.Files.Count > 0)
            //    {
            //        IFormFile file = httpRequest.Form.Files[0];
            //        Stream stream = files.OpenReadStream();

            //        IExcelDataReader reader = null;

            //        if (files.FileName.EndsWith(".xls"))
            //        {
            //            reader = ExcelReaderFactory.CreateBinaryReader(stream);
            //        }
            //        else if (files.FileName.EndsWith(".xlsx"))
            //        {
            //            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //        }
            //        else
            //        {
            //            message = "This file format is not supported";
            //        }

            //        DataSet excelRecords = reader.AsDataSet();
            //        reader.Close();

            //        var finalRecords = excelRecords.Tables[0];
            //        for (int i = 0; i < finalRecords.Rows.Count; i++)
            //        {
            //            TblCandidateList objUser = new TblCandidateList();
            //            objUser.ClEnrollmentNo = finalRecords.Rows[i][0].ToString();
            //            objUser.ClName = finalRecords.Rows[i][1].ToString();
            //            objUser.ClReqNo = (Int32)finalRecords.Rows[i][2];
            //            objUser.ClTheoryDeone = (Boolean)finalRecords.Rows[i][3];
            //            objUser.ClPracticalDone = (Boolean)finalRecords.Rows[i][4];

            //            _db.TblCandidateList.Add(objUser);

            //        }

            //        int output = _db.SaveChanges();
            //        if (output > 0)
            //        {
            //            message = "Excel file has been successfully uploaded";
            //        }
            //        else
            //        {
            //            message = "Excel file uploaded has fiald";
            //        }

            //    }

            //    else
            //    {
            //    result.StatusCode = HttpStatusCode.BadRequest;
            //    }
            return true;
        }


        //[HttpGet]
        //[Route("ExportCustomer")]
        //public List<> ExportCustomer()
        //{

        //    var result = _db.TblPracticalResult.GroupBy(o => o.PrCandidateId).Select(g => new {attainMarks = g.Sum(i => i.PrMarks), totalMarks = g.Sum(i => i.PrQuestionId) });
        //    foreach (var group in result)
        //    {
        //        Console.WriteLine("Marks Attained = {0} Total Marks={1}", group.attainMarks, group.totalMarks);
        //    }
        //    return result;
        //}
    }
}

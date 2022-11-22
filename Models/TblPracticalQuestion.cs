using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblPracticalQuestion
    {
        public TblPracticalQuestion()
        {
            TblPracticalResult = new HashSet<TblPracticalResult>();
        }

        public int PqCode { get; set; }
        public string PqNos { get; set; }
        public string PqPc { get; set; }
        public string PqQuestion { get; set; }
        public string PqType { get; set; }
        public int PqMarks { get; set; }
        public string PqVersionOfQb { get; set; }
        public string PqLang { get; set; }
        public string PqCommonQuestion { get; set; }

        public TblNos PqNosNavigation { get; set; }
        public TblQuestionPaperVersion PqVersionOfQbNavigation { get; set; }
        public ICollection<TblPracticalResult> TblPracticalResult { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblQp
    {
        public TblQp()
        {
            TblAssessmentBatch = new HashSet<TblAssessmentBatch>();
            TblNos = new HashSet<TblNos>();
            TblQuestionBank = new HashSet<TblQuestionBank>();
        }

        public string QpCode { get; set; }
        public string QpName { get; set; }
        public int? QpNsqfLevel { get; set; }
        public string QpSectorName { get; set; }
        public int QpNoOfNos { get; set; }
        public string QpMinEdlevel { get; set; }
        public string QpMaxEdlevel { get; set; }
        public bool QpActive { get; set; }

        public ICollection<TblAssessmentBatch> TblAssessmentBatch { get; set; }
        public ICollection<TblNos> TblNos { get; set; }
        public ICollection<TblQuestionBank> TblQuestionBank { get; set; }
    }
}

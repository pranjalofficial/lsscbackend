using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblPracticalResult
    {
        public int PrId { get; set; }
        public int? PrbatchId { get; set; }
        public string PrCandidateId { get; set; }
        public int? PrQuestionId { get; set; }
        public int? PrMarks { get; set; }
        public string PrNos { get; set; }
        public bool? PrType { get; set; }

        public TblNos PrNosNavigation { get; set; }
        public TblPracticalQuestion PrQuestion { get; set; }
        public TblAssessmentBatch Prbatch { get; set; }
    }
}

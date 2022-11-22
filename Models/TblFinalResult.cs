using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblFinalResult
    {
        public int FrId { get; set; }
        public int? FrbatchId { get; set; }
        public string FrCandidateId { get; set; }
        public int? FrTheoryId { get; set; }
        public int? FrPracticalId { get; set; }
        public int? FrTheoryResult { get; set; }
        public int? FrPracticalResult { get; set; }
        public int? FrFinalResult { get; set; }

        public TblTotalPracticalMarks FrPractical { get; set; }
        public TblTheoryResult FrTheory { get; set; }
        public TblAssessmentBatch Frbatch { get; set; }
    }
}

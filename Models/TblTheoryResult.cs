using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblTheoryResult
    {
        public TblTheoryResult()
        {
            TblFinalResult = new HashSet<TblFinalResult>();
        }

        public int TrId { get; set; }
        public int? TrbatchId { get; set; }
        public string TrCandidateId { get; set; }
        public int? TrMarks1 { get; set; }
        public int? TrMarks2 { get; set; }
        public int? TrMarks3 { get; set; }
        public int? TrMarks4 { get; set; }
        public int? TrMarks5 { get; set; }
        public int? TrMarks6 { get; set; }
        public int? TrMarks7 { get; set; }
        public int? TrMarks8 { get; set; }
        public int? TrMarks9 { get; set; }
        public int? TrMarks10 { get; set; }
        public int? TrMarks11 { get; set; }
        public int? TrMarks12 { get; set; }
        public int? TrMarks13 { get; set; }
        public int? TrMarks14 { get; set; }
        public int? TrMarks15 { get; set; }
        public int? TrMarks16 { get; set; }
        public int? TrMarks17 { get; set; }
        public int? TrMarks18 { get; set; }
        public int? TrMarks19 { get; set; }
        public int? TrMarks20 { get; set; }
        public int? TrTotalMarks { get; set; }

        public TblAssessmentBatch Trbatch { get; set; }
        public ICollection<TblFinalResult> TblFinalResult { get; set; }
    }
}

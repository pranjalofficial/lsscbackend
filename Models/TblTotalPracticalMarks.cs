using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblTotalPracticalMarks
    {
        public TblTotalPracticalMarks()
        {
            TblFinalResult = new HashSet<TblFinalResult>();
        }

        public int TpmId { get; set; }
        public int? TpmbatchId { get; set; }
        public string TpmCandidateId { get; set; }
        public int TpmTotalMarks { get; set; }

        public TblAssessmentBatch Tpmbatch { get; set; }
        public ICollection<TblFinalResult> TblFinalResult { get; set; }
    }
}

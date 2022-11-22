using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblQuestionPaperVersion
    {
        public TblQuestionPaperVersion()
        {
            TblAssessmentBatch = new HashSet<TblAssessmentBatch>();
            TblPracticalQuestion = new HashSet<TblPracticalQuestion>();
            TblTheoryQuestions = new HashSet<TblTheoryQuestions>();
        }

        public int QvVersionId { get; set; }
        public string QvVersionCode { get; set; }
        public string QvName { get; set; }
        public string QvType { get; set; }
        public string QvQbcode { get; set; }
        public bool? QvHindi { get; set; }
        public bool? QvTamil { get; set; }
        public bool? QvBangla { get; set; }

        public TblQuestionBank QvQbcodeNavigation { get; set; }
        public ICollection<TblAssessmentBatch> TblAssessmentBatch { get; set; }
        public ICollection<TblPracticalQuestion> TblPracticalQuestion { get; set; }
        public ICollection<TblTheoryQuestions> TblTheoryQuestions { get; set; }
    }
}

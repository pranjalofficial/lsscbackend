using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblQuestionBank
    {
        public TblQuestionBank()
        {
            TblAssessmentBatch = new HashSet<TblAssessmentBatch>();
            TblQuestionPaperVersion = new HashSet<TblQuestionPaperVersion>();
        }

        public int QbQuestionId { get; set; }
        public string QbQuestionCode { get; set; }
        public string QbName { get; set; }
        public string QbRelatedQp { get; set; }

        public TblQp QbRelatedQpNavigation { get; set; }
        public ICollection<TblAssessmentBatch> TblAssessmentBatch { get; set; }
        public ICollection<TblQuestionPaperVersion> TblQuestionPaperVersion { get; set; }
    }
}

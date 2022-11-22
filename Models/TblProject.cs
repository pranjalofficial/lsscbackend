using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblProject
    {
        public TblProject()
        {
            TblAssessmentBatch = new HashSet<TblAssessmentBatch>();
        }

        public string ProjId { get; set; }
        public string ProjName { get; set; }
        public string ProjDesp { get; set; }
        public string ProjManager { get; set; }
        public string ProjAssesmentType { get; set; }

        public ICollection<TblAssessmentBatch> TblAssessmentBatch { get; set; }
    }
}

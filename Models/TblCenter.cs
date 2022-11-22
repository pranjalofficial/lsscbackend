using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblCenter
    {
        public TblCenter()
        {
            TblAssessmentBatch = new HashSet<TblAssessmentBatch>();
        }

        public string CenterCode { get; set; }
        public string CenterName { get; set; }
        public string CenterAddress { get; set; }
        public string CenterContactPerson { get; set; }
        public long CenterContactNo { get; set; }
        public string CenterEmailId { get; set; }

        public ICollection<TblAssessmentBatch> TblAssessmentBatch { get; set; }
    }
}

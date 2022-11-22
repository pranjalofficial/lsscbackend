using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblAssessmentProof
    {
        public int AsId { get; set; }
        public int? AsbatchId { get; set; }
        public string AsCandidateId { get; set; }
        public string AsAssesser { get; set; }
        public byte[] AsPersonalPhoto { get; set; }
        public byte[] AsAddharPhoto { get; set; }

        public TblAssessmentBatch Asbatch { get; set; }
    }
}

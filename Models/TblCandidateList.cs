using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblCandidateList
    {
        public string ClEnrollmentNo { get; set; }
        public string ClName { get; set; }
        public int? ClReqNo { get; set; }
        public bool? ClPracticalDone { get; set; }
        public bool? ClTheoryDeone { get; set; }
    }
}

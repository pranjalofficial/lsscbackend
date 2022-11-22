using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblCompanyRequirment
    {
        public int CrId { get; set; }
        public string CrCompanyName { get; set; }
        public string CrRequestedDepartment { get; set; }
        public string CrFunction { get; set; }
        public int? CrNoOfPosition { get; set; }
        public string CrQualification { get; set; }
        public int? CrExperience { get; set; }
        public string CrSkillSets { get; set; }
        public string CrGender { get; set; }
        public int? CrPositionRequired { get; set; }
        public DateTime? CrDateOfJoining { get; set; }
        public string CrSpecificDetails { get; set; }
        public int? CrDuration { get; set; }
        public string CrState { get; set; }
        public string CrDistrict { get; set; }
    }
}

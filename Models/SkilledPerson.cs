using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class SkilledPerson
    {
        public int Id { get; set; }
        public string SpName { get; set; }
        public bool SpGender { get; set; }
        public long? SpAddhar { get; set; }
        public long? SpMobile { get; set; }
        public string SpFatherName { get; set; }
        public string SpAddress { get; set; }
        public long? SpPinCode { get; set; }
        public string SpDistrict { get; set; }
        public string SpState { get; set; }
        public string SpEducation { get; set; }
        public string SpWork { get; set; }
        public byte[] SpImage { get; set; }
        public string MotherName { get; set; }
        public string WorkedComapny { get; set; }
        public string LastDesignation { get; set; }
        public DateTime? SpDateOfBirth { get; set; }
    }
}

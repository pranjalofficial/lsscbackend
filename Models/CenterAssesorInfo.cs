using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CenterAssesorInfo
    {
        public int AsId { get; set; }
        public string AsContactPerson { get; set; }
        public string AsSdmsbatchName { get; set; }
        public string CenterName { get; set; }
        public string AsQuestionBankId { get; set; }
        public string AsQuestionVersion { get; set; }
        public bool? QvHindi { get; set; }
        public bool? QvTamil { get; set; }
        public bool? QvBangla { get; set; }
    }
}

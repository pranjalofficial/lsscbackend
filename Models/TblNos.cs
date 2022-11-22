using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TblNos
    {
        public TblNos()
        {
            TblPracticalQuestion = new HashSet<TblPracticalQuestion>();
            TblPracticalResult = new HashSet<TblPracticalResult>();
            TblTheoryQuestions = new HashSet<TblTheoryQuestions>();
        }

        public string NosCode { get; set; }
        public string NosName { get; set; }
        public bool NosActive { get; set; }
        public string NosQpCode { get; set; }

        public TblQp NosQpCodeNavigation { get; set; }
        public ICollection<TblPracticalQuestion> TblPracticalQuestion { get; set; }
        public ICollection<TblPracticalResult> TblPracticalResult { get; set; }
        public ICollection<TblTheoryQuestions> TblTheoryQuestions { get; set; }
    }
}

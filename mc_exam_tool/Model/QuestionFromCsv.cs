using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace McExamTool.Model
{
    [DelimitedRecord(";")]
    class QuestionFromCsv
    {
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public string CorrectAnswers { get; set; }
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Program.Application.DTOs
{
    public class QuestionDTO
    {
        public MultipleChoiceDTO? MultipleChoice { get; set; }
        public ParagraphDTO? ParagraphQuestion { get; set; }
        public NumericDTO? NumericQuestion { get; set; }
        public DropDownDTO? DropDownQuestion { get; set; }
        public YesNoDTO? YesNoQuestion { get; set; }
        public DateQuestionDTO? DateQuestion { get; set; }
    }
}

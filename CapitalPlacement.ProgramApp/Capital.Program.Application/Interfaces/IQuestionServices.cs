using Capital.Program.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capital.Program.Application.Interfaces
{
    public interface IQuestionServices
    {
        ValueTask<QuestionType> CreateQuestionType(QuestionType questionType);
        ValueTask<IEnumerable<QuestionType>> GetQuestionTypes();
        ValueTask<MultipleChoiceQuestion> CreateMultipleChoice(MultipleChoiceQuestion question);
        ValueTask<ParagraphQuestion> CreateParagraphQuestion(ParagraphQuestion question);
        ValueTask<DropDownQuestion> CreateDropDownQuestion(DropDownQuestion question);
        ValueTask<NumericQuestion> CreateNumericQuestion(NumericQuestion question);
        ValueTask<YesNoQuestion> CreateYesNoQuestion(YesNoQuestion question);
        ValueTask<DateQuestion> CreateDateQuestion(DateQuestion question);
        ValueTask<QuestionAnswer> CreateQuestionAnswer(QuestionAnswer questionAns);
        ValueTask<ParagraphQuestion> UpdateParagraph(ParagraphQuestion question);
        ValueTask<MultipleChoiceQuestion> UpdateMultipleChoice(MultipleChoiceQuestion question);
        ValueTask<DropDownQuestion> UpdateDropDownQuestion(DropDownQuestion question);
        ValueTask<NumericQuestion> UpdateNumericQuestion(NumericQuestion question);
        ValueTask<YesNoQuestion> UpdateYesNoQuestion(YesNoQuestion question);
        ValueTask<DateQuestion> UpdateDateQuestion(DateQuestion question);
        //ValueTask<QuestionDTO> GetQuestionByType(string questionTypeId);


    }
}


namespace Capital.Program.Infrastructure.Services
{
    public class QuestionService : IQuestionServices
    {
        private readonly CapitalProgramDbContext context;

        public QuestionService(CapitalProgramDbContext context)
        {
            this.context = context;
        }



        public async ValueTask<QuestionType> CreateQuestionType(QuestionType questionType)
        {
            var result = await context.QuestionTypes.AddAsync(questionType);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<IEnumerable<QuestionType>> GetQuestionTypes()
        {
            var result = await context.QuestionTypes.ToListAsync();
            return result;
        }

        public async ValueTask<YesNoQuestion> CreateYesNoQuestion(YesNoQuestion question)
        {
            var result = await context.YesNoQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<DateQuestion> CreateDateQuestion(DateQuestion question)
        {
            var result = await context.DateQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<DropDownQuestion> CreateDropDownQuestion(DropDownQuestion question)
        {
            var result = await context.DropDownQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<MultipleChoiceQuestion> CreateMultipleChoice(MultipleChoiceQuestion question)
        {
            var result = await context.MultipleChoiceQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<NumericQuestion> CreateNumericQuestion(NumericQuestion question)
        {
            var result = await context.NumericQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<ParagraphQuestion> CreateParagraphQuestion(ParagraphQuestion question)
        {
            var result = await context.ParagraphQuestions.AddAsync(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<QuestionAnswer> CreateQuestionAnswer(QuestionAnswer questionAns)
        {
            var result = await context.QuestionAnswers.AddAsync(questionAns);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<ParagraphQuestion> UpdateParagraph(ParagraphQuestion question)
        {
            var result = context.ParagraphQuestions.Update(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<MultipleChoiceQuestion> UpdateMultipleChoice(MultipleChoiceQuestion question)
        {
            var result = context.MultipleChoiceQuestions.Update(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<DropDownQuestion> UpdateDropDownQuestion(DropDownQuestion question)
        {
            var result = context.DropDownQuestions.Update(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<NumericQuestion> UpdateNumericQuestion(NumericQuestion question)
        {
            var result = context.NumericQuestions.Update(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<YesNoQuestion> UpdateYesNoQuestion(YesNoQuestion question)
        {
            var result = context.YesNoQuestions.Update(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async ValueTask<DateQuestion> UpdateDateQuestion(DateQuestion question)
        {
            var result = context.DateQuestions.Update(question);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        //public ValueTask<QuestionDTO> GetQuestionByType(string questionTypeId)
        //{
        //    var 
        //}

        //public async ValueTask<bool> UpdateQuestion(string questionTypedId, string employerProgramId)
        //{
        //    //var questionTyps = await context.QuestionTypes.ToListAsync();
        //    //string type = string.Empty;

        //    //foreach (var item in questionTyps)
        //    //{
        //    //    if (item.Id == questionTypedId)
        //    //    { 
        //    //        type = item.Type;
        //    //        if(type == )  
        //    //    }
        //    //}

        //    List<string> types = await context.QuestionTypes.Select(x=>x.Type).ToListAsync();

        //    var questionType = await context.QuestionTypes.FirstOrDefaultAsync(t => t.Id == questionTypedId);

        //    if (questionType.Type == "Paragraph") 
        //    {
        //        context.ParagraphQuestions.Update            
        //    }


        //}


    }
}

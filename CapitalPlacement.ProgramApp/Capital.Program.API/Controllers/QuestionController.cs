
namespace Capital.Program.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices questionServices;
        private readonly CapitalProgramDbContext context;

        public QuestionController(IQuestionServices questionServices, CapitalProgramDbContext context)
        {
            this.questionServices = questionServices;
            this.context = context;
        }

        [HttpGet("GetQuestionTypes")]
        public async ValueTask<ActionResult<IEnumerable<QuestionType>>> GetQuestionTypes()
        {
            return Ok(await questionServices.GetQuestionTypes());
        }

        [HttpPost("CreateQuestionType")]
        public async ValueTask<ActionResult<List<QuestionType>>> CreateQuestionType()
        {
            string[] questionTypes = new string[] { "Paragraph", "MultipleChoice", "Number", "YesNo", "Dropdown", "Date" };


            var existingTypes = await questionServices.GetQuestionTypes();

            if (existingTypes.Count() < questionTypes.Count())
            {
                var qTyp = new List<QuestionType>();

                foreach (var questionType in questionTypes)
                {

                    var questTyp = new QuestionType
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = questionType
                    };

                    var res = await questionServices.CreateQuestionType(questTyp);
                    qTyp.Add(res);
                }
                return Ok(qTyp);
            }

            return Ok(existingTypes);
        }

        [HttpPut("UpdateParagraphQuestion")]
        public async ValueTask<ActionResult<ParagraphQuestion>> UpdateParagraphQuestion([FromBody] ParagraphDTO data)
        {
            var question = await context.ParagraphQuestions.Where(x => x.EmployerProgramId == data.EmployerProgramId
            && x.QuestionTypeId == data.QuestionTypeId).FirstOrDefaultAsync();

            question.Question = data.Question;

            var result = context.ParagraphQuestions.Update(question);
            await context.SaveChangesAsync();

            return Ok(result.Entity);
        }

        [HttpPut("UpdateNumericQuestion")]
        public async ValueTask<ActionResult<NumericQuestion>> UpdateNumericQuestion([FromBody] NumericDTO data)
        {
            var question = await context.NumericQuestions.Where(x => x.EmployerProgramId == data.EmployerProgramId
            && x.QuestionTypeId == data.QuestionTypeId).FirstOrDefaultAsync();

            question.Question = data.Question;

            var result = context.NumericQuestions.Update(question);
            await context.SaveChangesAsync();

            return Ok(result.Entity);
        }

        [HttpPut("UpdateYesNoQuestion")]
        public async ValueTask<ActionResult<YesNoQuestion>> UpdateYesNoQuestion([FromBody] YesNoDTO data)
        {
            var question = await context.YesNoQuestions.Where(x => x.EmployerProgramId == data.EmployerProgramId
            && x.QuestionTypeId == data.QuestionTypeId).FirstOrDefaultAsync();

            question.Question = data.Question;

            var result = context.YesNoQuestions.Update(question);
            await context.SaveChangesAsync();

            return Ok(result.Entity);
        }

        [HttpPut("UpdateDateQuestion")]
        public async ValueTask<ActionResult<DateQuestion>> UpdateDateQuestion([FromBody] DateQuestionDTO data)
        {
            var question = await context.DateQuestions.Where(x => x.EmployerProgramId == data.EmployerProgramId
            && x.QuestionTypeId == data.QuestionTypeId).FirstOrDefaultAsync();

            question.Question = data.Question;

            var result = context.DateQuestions.Update(question);
            await context.SaveChangesAsync();

            return Ok(result.Entity);
        }

        [HttpPut("UpdateMultipleChoiceQuestion")]
        public async ValueTask<ActionResult<MultipleChoiceQuestion>> UpdateMultipleChoiceQuestion([FromBody] MultipleChoiceDTO data)
        {
            var question = await context.MultipleChoiceQuestions.Where(x => x.EmployerProgramId == data.EmployerProgramId
            && x.QuestionTypeId == data.QuestionTypeId).FirstOrDefaultAsync();

            question.Question = data.Question;
            question.Choices = String.Join(",", data.Choices);
            question.IsOthers = data.IsOthers;
            question.MaxChoiceAllowed = data.MaxChoiceAllowed;

            var result = context.MultipleChoiceQuestions.Update(question);
            await context.SaveChangesAsync();

            return Ok(result.Entity);
        }

        [HttpPut("UpdateDropDownQuestion")]
        public async ValueTask<ActionResult<DropDownQuestion>> UpdateDropDownQuestion([FromBody] DropDownDTO data)
        {
            var question = await context.DropDownQuestions.Where(x => x.EmployerProgramId == data.EmployerProgramId
            && x.QuestionTypeId == data.QuestionTypeId).FirstOrDefaultAsync();

            question.Question = data.Question;
            question.Choices = String.Join(",", data.Choices);
            question.IsOthers = data.IsOthers;

            var result = context.DropDownQuestions.Update(question);
            await context.SaveChangesAsync();

            return Ok(result.Entity);
        }

        [HttpPost("GetQuestionByType")]
        public async ValueTask<ActionResult> GetQuestionByType([FromBody] QuestionByTypeDTO dto)
        {
            if (dto == null)
                return BadRequest();

            if (string.Equals(dto.QuestionTypeName, QuestionTypes.MultipleChoice.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var result = await context.MultipleChoiceQuestions
                    .Where(x => x.EmployerProgramId == dto.EmployerProgramId).FirstOrDefaultAsync();

                return Ok(new MultipleChoiceDTO 
                {
                    Question = result.Question,
                    QuestionTypeId = result.QuestionTypeId,
                    EmployerProgramId = result.EmployerProgramId,
                    Choices = result.Choices.Split(',').ToList(),
                    IsOthers = result.IsOthers,
                    MaxChoiceAllowed = result.MaxChoiceAllowed
                });
            }
            else if (string.Equals(dto.QuestionTypeName, QuestionTypes.Dropdown.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var result = await context.DropDownQuestions
                    .Where(x => x.EmployerProgramId == dto.EmployerProgramId).FirstOrDefaultAsync();

                return Ok(new DropDownDTO
                {
                    Question = result.Question,
                    QuestionTypeId = result.QuestionTypeId,
                    EmployerProgramId = result.EmployerProgramId,
                    Choices = result.Choices.Split(',').ToList(),
                    IsOthers = result.IsOthers,
                });
            }
            else if (string.Equals(dto.QuestionTypeName, QuestionTypes.Paragraph.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var result = await context.ParagraphQuestions
                    .Where(x => x.EmployerProgramId == dto.EmployerProgramId).FirstOrDefaultAsync();

                return Ok(new ParagraphDTO
                {
                    Question = result.Question,
                    QuestionTypeId = result.QuestionTypeId,
                    EmployerProgramId = result.EmployerProgramId
                });
            }
            else if (string.Equals(dto.QuestionTypeName, QuestionTypes.Number.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var result = await context.NumericQuestions
                    .Where(x => x.EmployerProgramId == dto.EmployerProgramId).FirstOrDefaultAsync();

                return Ok(new NumericDTO
                {
                    Question = result.Question,
                    QuestionTypeId = result.QuestionTypeId,
                    EmployerProgramId = result.EmployerProgramId
                });
            }
            else if (string.Equals(dto.QuestionTypeName, QuestionTypes.YesNo.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var result = await context.YesNoQuestions
                    .Where(x => x.EmployerProgramId == dto.EmployerProgramId).FirstOrDefaultAsync();

                return Ok(new YesNoDTO
                {
                    Question = result.Question,
                    QuestionTypeId = result.QuestionTypeId,
                    EmployerProgramId = result.EmployerProgramId
                });
            }
            else if (string.Equals(dto.QuestionTypeName, QuestionTypes.Date.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var result = await context.DateQuestions
                    .Where(x => x.EmployerProgramId == dto.EmployerProgramId).FirstOrDefaultAsync();

                return Ok(new DateQuestionDTO
                {
                    Question = result.Question,
                    QuestionTypeId = result.QuestionTypeId,
                    EmployerProgramId = result.EmployerProgramId
                });
            }
            else
            { 
                return NoContent();
            }
        }
    }
}

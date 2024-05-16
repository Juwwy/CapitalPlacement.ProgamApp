namespace Capital.Program.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployerProgramController : ControllerBase
    {
        private readonly IEmployerProgramService programService;
        private readonly IValidator<EmployerProgramDTO> validator;
        private readonly IQuestionServices questionServices;

        public EmployerProgramController(IEmployerProgramService programService,
            IValidator<EmployerProgramDTO> validator, IQuestionServices questionServices)
        {
            this.programService = programService;
            this.validator = validator;
            this.questionServices = questionServices;
        }

        [HttpGet]
        public async ValueTask<ActionResult<List<EmployerProgram>>> Get()
        {
            var result = await programService.GetProgramsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<List<EmployerProgram>>> Get(string id)
        {
            var result = await programService.GetProgramAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<ActionResult<EmployerProgram>> Post([FromBody] EmployerProgramDTO data)
        {
            try
            {
                var validatorResult = await validator.ValidateAsync(data);

                if (!validatorResult.IsValid)
                {
                    validatorResult.Errors.ForEach(e => ModelState.AddModelError("error", e.ErrorMessage));
                    return ValidationProblem(instance: "100", modelStateDictionary: ModelState);
                }

                #region EntityMapping
                var empProgram = new EmployerProgram
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = data.Title,
                    Description = data.Description,
                    FirstNameRequired = data.FirstNameRequired,
                    LastNameRequired = data.LastNameRequired,
                    EmailRequired = data.EmailRequired,
                    CurrentResidenceHide = data.CurrentResidenceHide,
                    CurrentResidenceInternal = data.CurrentResidenceInternal,
                    NationalityHide = data.NationalityHide,
                    NationalityInternal = data.NationalityInternal,
                    DateOfBirthHide = data.DateOfBirthHide,
                    DateOfBirthInternal = data.DateOfBirthInternal,
                    GenderHide = data.GenderHide,
                    GenderInternal = data.GenderInternal,
                    IDNumberInternal = data.IDNumberInternal,
                    IDNUmberHide = data.IDNUmberHide,
                    PhoneHide = data.PhoneHide,
                    PhoneInternal = data.PhoneInternal

                };
                #endregion


                var result = await this.programService.CreateProgramAsync(empProgram);

                if (result != null)
                {
                    #region Questions
                    var DateQuestion = new DateQuestion
                    {
                        Id = Guid.NewGuid().ToString(),
                        Question = data.DateQuestion.Question,
                        QuestionTypeId = data.DateQuestion.QuestionTypeId,
                        EmployerProgramId = result.Id

                    };
                    var MultipleChoiceQuestion = new MultipleChoiceQuestion
                    {
                        Id = Guid.NewGuid().ToString(),
                        Question = data.MultipleChoice.Question,
                        QuestionTypeId = data.MultipleChoice.QuestionTypeId,
                        Choices = string.Join(",", data.MultipleChoice.Choices),
                        EmployerProgramId = result.Id,
                        MaxChoiceAllowed = data.MultipleChoice.MaxChoiceAllowed,
                        IsOthers = data.MultipleChoice.IsOthers
                    };
                    var ParagraphQuestion = new ParagraphQuestion
                    {
                        Id = Guid.NewGuid().ToString(),
                        Question = data.ParagraphQuestion.Question,
                        QuestionTypeId = data.ParagraphQuestion.QuestionTypeId,
                        EmployerProgramId = result.Id
                    };
                    var DropDownQuestion = new DropDownQuestion
                    {
                        Id = Guid.NewGuid().ToString(),
                        Question = data.DropDownQuestion.Question,
                        QuestionTypeId = data.DropDownQuestion.QuestionTypeId,
                        Choices = string.Join(",", data.DropDownQuestion.Choices),
                        EmployerProgramId = result.Id,
                        IsOthers = data.DropDownQuestion.IsOthers
                    };
                    var NumericQuestion = new NumericQuestion
                    {
                        Id = Guid.NewGuid().ToString(),
                        Question = data.NumericQuestion.Question,
                        QuestionTypeId = data.NumericQuestion.QuestionTypeId,
                        EmployerProgramId = result.Id
                    };

                    var YesNoQuestion = new YesNoQuestion
                    {
                        Id = Guid.NewGuid().ToString(),
                        Question = data.YesNoQuestion.Question,
                        QuestionTypeId = data.YesNoQuestion.QuestionTypeId,
                        EmployerProgramId = result.Id
                    };
                    #endregion
                    await questionServices.CreateDateQuestion(DateQuestion);
                    await questionServices.CreateYesNoQuestion(YesNoQuestion);
                    await questionServices.CreateNumericQuestion(NumericQuestion);
                    await questionServices.CreateDropDownQuestion(DropDownQuestion);
                    await questionServices.CreateMultipleChoice(MultipleChoiceQuestion);
                    await questionServices.CreateParagraphQuestion(ParagraphQuestion);
                }

                return Ok(new EmployerProgram { Id = result.Id, Title = result.Title, Description = result.Description });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async ValueTask<ActionResult<EmployerProgram>> Put(string id, UpdateEmployerProgramDTO data)
        {
            var result = await programService.GetProgramAsync(id);

            result.Title = data.Title != null ? data.Title : result.Title;
            result.Description = data.Description != null ? data.Description : result.Description;

            if (result == null) return NotFound();

            var updatedData = await programService.UpdateProgramAsync(result);

            return Ok(updatedData);

        }

        [HttpDelete("{id}")]
        public async ValueTask<ActionResult<EmployerProgram>> Delete(string id)
        {

            var result = await programService.GetProgramAsync(id);

            if (result == null) return NotFound();

            var deletedData = await programService.RemoveProgramAsync(result);

            return Ok(deletedData);
        }
    }
}

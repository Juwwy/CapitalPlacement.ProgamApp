namespace Capital.Program.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService profileService;
        private readonly IValidator<UserProfileDTO> validator;
        private readonly IQuestionServices questionServices;
        private readonly IEmployerProgramService employerProgramService;
        private readonly CapitalProgramDbContext context;

        public UserProfileController(IUserProfileService profileService,
            IValidator<UserProfileDTO> validator, IQuestionServices questionServices,
            IEmployerProgramService employerProgramService, CapitalProgramDbContext context)
        {
            this.profileService = profileService;
            this.validator = validator;
            this.questionServices = questionServices;
            this.employerProgramService = employerProgramService;
            this.context = context;
        }

        [HttpGet]
        public async ValueTask<ActionResult<List<UserProfile>>> Get()
        {
            var results = await this.profileService.GetUsersAsync();

            return Ok(results);

        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<UserProfile>> Get(string id)
        {
            var result = await profileService.GetUserAsync(id);

            if (result == null) return NotFound();

            return Ok(result);

        }

        [HttpPost]
        public async ValueTask<ActionResult<UserProfile>> Post([FromBody] UserProfileDTO userProfile)
        {
            try
            {
                var validatorResult = await validator.ValidateAsync(userProfile);

                if (!validatorResult.IsValid)
                {
                    validatorResult.Errors.ForEach(e => ModelState.AddModelError("error", e.ErrorMessage));
                    return ValidationProblem(instance: "100", modelStateDictionary: ModelState);
                }

                var profileData = new UserProfile
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    EmailAddress = userProfile.EmailAddress,
                    CurrentResidence = userProfile.CurrentResidence,
                    Phone = userProfile.Phone,
                    Gender = userProfile.Gender,
                    DateOfBirth = userProfile.DateOfBirth,
                    IdNumber = userProfile.IdNumber,
                    Nationality = userProfile.Nationality,
                    EmployerProgramId = userProfile.EmployerProgramId,
                };

                var result = await profileService.CreateUserAsync(profileData);

                if (result != null)
                {
                    if (result.QuestionAnswers.Count() > 0)
                    {
                        foreach (var item in userProfile.Answers)
                        {
                            //Create answers here

                            var answer = new QuestionAnswer
                            {
                                Id = Guid.NewGuid().ToString(),
                                Answer = item.Answer,
                                EmployerProgramId = userProfile.EmployerProgramId,
                                QuestionTypeId = item.QuestionTypeId,
                                UserProfileId = result.Id
                            };

                            await questionServices.CreateQuestionAnswer(answer);
                        }
                    }
                }

                return Ok(new UserProfileDTO { FirstName = result.FirstName, LastName = result.LastName, EmailAddress = result.EmailAddress, CurrentResidence = result.CurrentResidence, Phone = result.Phone, Gender = result.Gender, DateOfBirth = result.DateOfBirth, IdNumber = result.IdNumber, Nationality = result.Nationality });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async ValueTask<ActionResult<UserProfile>> Put(string id, UpdateUserProfileDTO data)
        {
            var result = await profileService.GetUserAsync(id);

            if (result == null) return NotFound();

            result.FirstName = data.FirstName != null ? data.FirstName : result.FirstName;
            result.LastName = data.LastName != null ? data.LastName : result.LastName;
            result.EmailAddress = data.EmailAddress != null ? data.EmailAddress : result.EmailAddress;
            result.Phone = data.Phone != null ? data.Phone : result.Phone;
            result.IdNumber = data.IdNumber != null ? data.IdNumber : result.IdNumber;
            result.Nationality = data.Nationality != null ? data.Nationality : result.Nationality;
            result.Gender = data.Gender != null ? data.Gender : result.Gender;
            result.DateOfBirth = data.DateOfBirth != null ? data.DateOfBirth : result.DateOfBirth;
            result.CurrentResidence = data.CurrentResidence != null ? data.CurrentResidence : result.CurrentResidence;

            var updatedData = await profileService.UpdateUserAsync(result);

            return Ok(updatedData);

        }

        [HttpDelete("{id}")]
        public async ValueTask<ActionResult<UserProfile>> Delete(string id)
        {
            var result = await profileService.GetUserAsync(id);

            if (result == null) return NotFound();

            var deletedData = await profileService.RemoveUserAsync(result);

            return Ok(deletedData);

        }

        [HttpGet("GetProfilewithQuestion/{employerProgramId}")]
        public async ValueTask<ActionResult<EmployerProgramDTO>> GetProfilewithQuestion(string employerProgramId)
        {
            var program = await employerProgramService.GetProgramAsync(employerProgramId);
            if (program == null) return BadRequest();

            var paragraphQuest = await context.ParagraphQuestions.Where(x => x.EmployerProgramId == employerProgramId).FirstOrDefaultAsync();
            var dropDownQuest = await context.DropDownQuestions.Where(x => x.EmployerProgramId == employerProgramId).FirstOrDefaultAsync();
            var multipleChoiceQuest = await context.MultipleChoiceQuestions.Where(x => x.EmployerProgramId == employerProgramId).FirstOrDefaultAsync();
            var numericQuest = await context.NumericQuestions.Where(x => x.EmployerProgramId == employerProgramId).FirstOrDefaultAsync();
            var yesNoQuest = await context.YesNoQuestions.Where(x => x.EmployerProgramId == employerProgramId).FirstOrDefaultAsync();
            var dateQuest = await context.DateQuestions.Where(x => x.EmployerProgramId == employerProgramId).FirstOrDefaultAsync();

            return Ok(new EmployerProgramDTO
            {
                Title = program.Title,
                Description = program.Description,
                ParagraphQuestion = new ParagraphDTO
                {
                    Question = paragraphQuest.Question,
                    QuestionTypeId = paragraphQuest.QuestionTypeId,
                    EmployerProgramId = paragraphQuest.EmployerProgramId,
                },
                MultipleChoice = new MultipleChoiceDTO
                {
                    Question = multipleChoiceQuest.Question,
                    QuestionTypeId = multipleChoiceQuest.QuestionTypeId,
                    EmployerProgramId = multipleChoiceQuest.EmployerProgramId,
                    IsOthers = multipleChoiceQuest.IsOthers,
                    MaxChoiceAllowed = multipleChoiceQuest.MaxChoiceAllowed,
                    Choices = multipleChoiceQuest.Choices.Split(',').ToList()
                },
                DateQuestion = new DateQuestionDTO
                {
                    Question = dateQuest.Question,
                    QuestionTypeId = dateQuest.QuestionTypeId,
                    EmployerProgramId = dateQuest.EmployerProgramId
                },
                YesNoQuestion = new YesNoDTO
                {
                    Question = yesNoQuest.Question,
                    QuestionTypeId = yesNoQuest.QuestionTypeId,
                    EmployerProgramId = yesNoQuest.EmployerProgramId
                },
                DropDownQuestion = new DropDownDTO
                {
                    Question = dropDownQuest.Question,
                    QuestionTypeId = dropDownQuest.QuestionTypeId,
                    EmployerProgramId = dropDownQuest.EmployerProgramId,
                    IsOthers = dropDownQuest.IsOthers,
                    Choices = dropDownQuest.Choices.Split(",").ToList()
                },
                NumericQuestion = new NumericDTO
                {
                    Question = numericQuest.Question,
                    QuestionTypeId = numericQuest.QuestionTypeId,
                    EmployerProgramId = numericQuest.EmployerProgramId
                }
            });

        }
    }
}

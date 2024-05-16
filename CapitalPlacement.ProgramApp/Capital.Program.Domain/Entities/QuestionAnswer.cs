
namespace Capital.Program.Domain.Entities
{
    public class QuestionAnswer
    {
        public string Id { get; set; }
        public string Answer { get; set; }
        public string QuestionTypeId { get; set; }
        public string? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
        public string? EmployerProgramId { get; set; }
        public EmployerProgram? EmployerProgram { get; set; }
    }
}

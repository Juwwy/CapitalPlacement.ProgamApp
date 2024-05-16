
namespace Capital.Program.Domain.Entities
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string? IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public string EmployerProgramId { get; set; }
        public EmployerProgram? EmployerProgram { get; set; }
        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}

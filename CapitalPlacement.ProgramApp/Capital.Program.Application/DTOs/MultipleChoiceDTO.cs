
namespace Capital.Program.Application.DTOs
{
    public class MultipleChoiceDTO
    {
        public string Question { get; set; }
        public string QuestionTypeId { get; set; }
        public string? EmployerProgramId { get; set; }
        public List<string> Choices { get; set; }
        public bool IsOthers { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }
}

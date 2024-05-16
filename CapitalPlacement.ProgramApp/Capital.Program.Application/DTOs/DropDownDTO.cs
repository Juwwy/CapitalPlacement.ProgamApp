
namespace Capital.Program.Application.DTOs
{
    public class DropDownDTO
    {
        public string Question { get; set; }
        public string QuestionTypeId { get; set; }
        public string? EmployerProgramId { get; set; }
        public List<string> Choices { get; set; }
        public bool IsOthers { get; set; }
    }
}

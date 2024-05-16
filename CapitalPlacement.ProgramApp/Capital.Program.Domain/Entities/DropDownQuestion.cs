
namespace Capital.Program.Domain.Entities
{
    public class DropDownQuestion : QuestionCommon
    {
        public string Choices { get; set; }
        public bool IsOthers { get; set; }

    }
}

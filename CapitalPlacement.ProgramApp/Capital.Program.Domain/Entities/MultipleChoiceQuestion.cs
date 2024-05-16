
namespace Capital.Program.Domain.Entities
{
    public class MultipleChoiceQuestion : QuestionCommon
    {
        public string Choices { get; set; }
        public bool IsOthers { get; set; }
        public int MaxChoiceAllowed { get; set; }
    }
}

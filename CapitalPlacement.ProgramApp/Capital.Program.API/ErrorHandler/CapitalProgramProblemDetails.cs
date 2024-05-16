
namespace Capital.Program.API.ErrorHandler
{
    public class CapitalProgramProblemDetails : ProblemDetails
    {
        public Dictionary<string, List<string>>? Errors { get; set; }
        public string? TraceIdentifier { get; set; }
        public string? Path { get; set; }
    }
}

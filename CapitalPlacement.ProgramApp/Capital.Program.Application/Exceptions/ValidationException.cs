
namespace Capital.Program.Application.Exceptions
{
    public class ValidationException : System.Exception
    {
        public List<string> ValdationErrors { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public string? Instance { get; set; }
        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();
            Errors = new Dictionary<string, List<string>>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
                if (Errors.ContainsKey(validationError.PropertyName))
                {
                    Errors[validationError.PropertyName].Add(validationError.ErrorMessage);
                }
                else
                {
                    Errors.Add(validationError.PropertyName, new List<string> { validationError.ErrorMessage });
                }
            }
        }
    }
}

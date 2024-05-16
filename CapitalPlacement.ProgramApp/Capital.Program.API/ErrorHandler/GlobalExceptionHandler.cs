
using ValidationException = Capital.Program.Application.Exceptions.ValidationException;

namespace Capital.Program.API.ErrorHandler
{
    public static class GlobalExceptionHandler
    {
        public static void UseGlobalException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception != null)
                    {
                        // logger.LogError(exception.Error, "");

                        var problemDetails = new CapitalProgramProblemDetails();
                        if (exception.Error.GetType() == typeof(ValidationException))
                        {
                            ValidationException err = exception.Error as ValidationException;
                            if (err != null)
                            {
                                problemDetails.Errors = err.Errors;
                                problemDetails.Detail = "Bad request";
                                problemDetails.Status = 400;
                                problemDetails.Type = err.HelpLink;
                                problemDetails.Title = "One or more validation errors occurred.";
                                problemDetails.Instance = err.Instance ?? "100";
                                problemDetails.TraceIdentifier = context.TraceIdentifier;
                                problemDetails.Path = context.Request.Path;
                            }
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            // problemDetails.Errors = err.Errors;
                            problemDetails.Detail = "internal server error";
                            problemDetails.Status = 500;
                            problemDetails.Type = "";
                            problemDetails.Title = "internal server error.";
                            problemDetails.TraceIdentifier = context.TraceIdentifier;
                            problemDetails.Path = context.Request.Path;
                        }

                        await context.Response.WriteAsJsonAsync(problemDetails);
                    }

                });
            });
        }
    }
}

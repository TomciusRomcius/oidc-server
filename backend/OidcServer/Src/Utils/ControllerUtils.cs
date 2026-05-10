using Microsoft.AspNetCore.Mvc;

namespace OidcServer.Utils;

public static class ControllerUtils
{
    public static IActionResult ResultErrorToResponse(ResultError error)
    {
        int statusCode = ResultErrorTypeToStatusCode(error.ErrorType);

        var problemDetails = new ProblemDetails
        {
            Title = error.Message,
            Detail = error.Message,
            Status = statusCode
        };

        return new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };
    }

    private static int ResultErrorTypeToStatusCode(ResultErrorType errorType)
    {
        return errorType switch
        {
            ResultErrorType.Validation => 400,
            ResultErrorType.InvalidOperation => 400,
            ResultErrorType.Forbidden => 403,
            _ => 500
        };
    }
}

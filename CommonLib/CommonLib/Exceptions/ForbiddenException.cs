using CommonLib.Response;

namespace CommonLib.Exceptions;


public class ForbiddenException : ExceptionResponse
{
    public static ForbiddenException Throw(string message)
        => throw new ForbiddenException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.Forbidden
     };
}

using CommonLib.Response;

namespace CommonLib.Exceptions;


public class PreconditionRequiredException : ExceptionResponse
{
    public static PreconditionRequiredException Throw(string message)
        => throw new PreconditionRequiredException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.PreconditionRequired
     };
}

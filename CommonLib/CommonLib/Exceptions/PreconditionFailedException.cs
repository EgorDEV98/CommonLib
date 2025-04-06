using CommonLib.Response;

namespace CommonLib.Exceptions;


public class PreconditionFailedException : ExceptionResponse
{
    public static PreconditionFailedException Throw(string message)
        => throw new PreconditionFailedException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.PreconditionFailed
     };
}

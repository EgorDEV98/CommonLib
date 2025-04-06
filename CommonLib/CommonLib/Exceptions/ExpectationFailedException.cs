using CommonLib.Response;

namespace CommonLib.Exceptions;

public class ExpectationFailedException : ExceptionResponse
{
    public static ExpectationFailedException Throw(string message)
        => throw new ExpectationFailedException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.ExpectationFailed
     };
}

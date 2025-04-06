using CommonLib.Response;

namespace CommonLib.Exceptions;


public class TooManyRequestsException : ExceptionResponse
{
    public static TooManyRequestsException Throw(string message)
        => throw new TooManyRequestsException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.TooManyRequests
     };
}

using CommonLib.Response;

namespace CommonLib.Exceptions;


public class RequestEntityTooLargeException : ExceptionResponse
{
    public static RequestEntityTooLargeException Throw(string message)
        => throw new RequestEntityTooLargeException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.RequestEntityTooLarge
     };
}

using CommonLib.Response;

namespace CommonLib.Exceptions;


public class MethodNotAllowedException : ExceptionResponse
{
    public static MethodNotAllowedException Throw(string message)
        => throw new MethodNotAllowedException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.MethodNotAllowed
     };
}

using CommonLib.Response;

namespace CommonLib.Exceptions;


public class ServiceUnavailableException : ExceptionResponse
{
    public static ServiceUnavailableException Throw(string message)
        => throw new ServiceUnavailableException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.ServiceUnavailable
     };
}

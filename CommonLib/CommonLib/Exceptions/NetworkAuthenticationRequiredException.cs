using CommonLib.Response;

namespace CommonLib.Exceptions;


public class NetworkAuthenticationRequiredException : ExceptionResponse
{
    public static NetworkAuthenticationRequiredException Throw(string message)
        => throw new NetworkAuthenticationRequiredException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.NetworkAuthenticationRequired
     };
}

using CommonLib.Response;

namespace CommonLib.Exceptions;


public class GoneException : ExceptionResponse
{
    public static GoneException Throw(string message)
        => throw new GoneException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.Gone
     };
}

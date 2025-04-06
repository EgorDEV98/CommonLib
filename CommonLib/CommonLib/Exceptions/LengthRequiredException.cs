using CommonLib.Response;

namespace CommonLib.Exceptions;


public class LengthRequiredException : ExceptionResponse
{
    public static LengthRequiredException Throw(string message)
        => throw new LengthRequiredException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.LengthRequired
     };
}

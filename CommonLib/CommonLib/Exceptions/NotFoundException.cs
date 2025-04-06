using CommonLib.Response;

namespace CommonLib.Exceptions;


public class NotFoundException : ExceptionResponse
{
    public static NotFoundException Throw(string message)
        => throw new NotFoundException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.NotFound
     };
}

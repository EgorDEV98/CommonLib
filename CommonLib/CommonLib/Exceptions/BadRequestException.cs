using CommonLib.Response;

namespace CommonLib.Exceptions;

public class BadRequestException : ExceptionResponse
{
    public static BadRequestException Throw(string message)
        => throw new BadRequestException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.BadRequest
     };
}

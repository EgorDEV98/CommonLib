using CommonLib.Response;

namespace CommonLib.Exceptions;

public class BadGatewayException : ExceptionResponse
{
    public static BadGatewayException Throw(string message)
        => throw new BadGatewayException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.BadGateway
     };
}

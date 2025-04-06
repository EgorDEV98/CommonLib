using CommonLib.Response;

namespace CommonLib.Exceptions;


public class UnprocessableEntityException : ExceptionResponse
{
    public static UnprocessableEntityException Throw(string message)
        => throw new UnprocessableEntityException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity
     };
}

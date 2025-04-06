using CommonLib.Response;

namespace CommonLib.Exceptions;


public class UnsupportedMediaTypeException : ExceptionResponse
{
    public static UnsupportedMediaTypeException Throw(string message)
        => throw new UnsupportedMediaTypeException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.UnsupportedMediaType
     };
}

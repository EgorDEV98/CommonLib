using CommonLib.Response;

namespace CommonLib.Exceptions;


public class PaymentRequiredException : ExceptionResponse
{
    public static PaymentRequiredException Throw(string message)
        => throw new PaymentRequiredException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.PaymentRequired
     };
}

using CommonLib.Response;

namespace CommonLib.Exceptions;


public class LockedException : ExceptionResponse
{
    public static LockedException Throw(string message)
        => throw new LockedException()
     {
            StatusMessage = message,
            HttpStatusCode = System.Net.HttpStatusCode.Locked
     };
}

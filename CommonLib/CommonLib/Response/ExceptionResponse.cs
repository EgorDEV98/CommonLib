using CommonLib.Response.Enums;

namespace CommonLib.Response;

public class ExceptionResponse : Exception
{
    public ResponseStatus Status { get; set; } = ResponseStatus.Error;
    public string StatusMessage { get; set; } = null!;
    public System.Net.HttpStatusCode? HttpStatusCode { get; set; }
}
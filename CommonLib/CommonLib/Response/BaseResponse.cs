
using CommonLib.Response.Enums;

namespace CommonLib.Response;

public class BaseResponse<T> : BaseResponse
{
    public T? Data { get; set; }
}

public class BaseResponse
{
    public ResponseStatus Status { get; set; } = ResponseStatus.Success;
    public string StatusMessage {  get; set; } = null!;
}

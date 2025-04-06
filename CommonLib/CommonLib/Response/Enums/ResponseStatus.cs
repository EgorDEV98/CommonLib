using System.Runtime.Serialization;

namespace CommonLib.Response.Enums;

public enum ResponseStatus
{
    /// <summary>
    /// Успшно
    /// </summary>
    [EnumMember(Value = "SUCCESS")]
    Success,
    
    /// <summary>
    /// Ошибка
    /// </summary>
    [EnumMember(Value = "ERROR")]
    Error,
}
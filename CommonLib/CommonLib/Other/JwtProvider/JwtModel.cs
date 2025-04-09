namespace CommonLib.Other.JwtProvider;

/// <summary>
/// Модель для создания JWT токена
/// </summary>
public class JwtModel
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Guid UserId { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }
}
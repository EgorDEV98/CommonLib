namespace CommonLib.EFCore.Interfaces;

/// <summary>
/// Интерфейс для базовой сущности
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Дата создания объекта
    /// </summary>
    public DateTime CreatedDate { get; set; }
    
    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime LastUpdate { get; set; }
}
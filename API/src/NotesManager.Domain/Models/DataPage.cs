using NotesManager.Domain.Entities;

namespace NotesManager.Domain.Models;

/// <summary>
/// Модель для постраничного вывода
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public class DataPage<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Общее количество объектов в бд
    /// </summary>
    public int TotalCount { get; init; }

    /// <summary>
    /// Объекты на странице
    /// </summary>
    public List<TEntity> Data { get; init; } = new();
}
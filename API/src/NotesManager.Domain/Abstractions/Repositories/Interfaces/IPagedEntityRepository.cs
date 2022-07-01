using System.Linq.Expressions;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Models;

namespace NotesManager.Domain.Abstractions.Repositories.Interfaces;

/// <summary>
/// Репозиторий с поддержкой постраничного вывода
/// </summary>
public interface IPagedEntityRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Асинхронно осуществляет постраничный вывод объектов, удовлетворяющих условию выражения
    /// </summary>
    /// <param name="expression">Выражение</param>
    /// <param name="skip">Количество объектов, которые следует пропустить</param>
    /// <param name="take">Количество элементов на странице</param>
    /// <returns>Задача, которая содержит объект постраничного вывода</returns>
    Task<DataPage<TEntity>> GetPagedEntitiesByExpressionAsync(
        Expression<Func<TEntity, bool>> expression,
        int skip,
        int take
    );
}
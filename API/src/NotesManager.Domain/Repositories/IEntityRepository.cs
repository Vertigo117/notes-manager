using System.Linq.Expressions;
using NotesManager.Domain.Entities;

namespace NotesManager.Domain.Repositories;

/// <summary>
/// Репозиторий для доступа к данным
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
public interface IEntityRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Асинхронно получает объекты, соответствующие условию
    /// </summary>
    /// <param name="expression">Условие</param>
    /// <returns>Задача, которая содержит коллекцию объектов <typeparamref name="TEntity"/></returns>
    Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Асинхронно получает объект по уникальному идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор</param>
    /// <returns>Задача, которая содержит объект с указанным уникальным идентификатором, либо <c>null</c>,
    /// если объект не найден</returns>
    Task<TEntity?> GetByIdOrDefaultAsync(int id);

    /// <summary>
    /// Асинхронно создаёт новый объект
    /// </summary>
    /// <param name="entity">Объект для создания</param>
    void Create(TEntity entity);

    /// <summary>
    /// Обновляет информацию об объекте
    /// </summary>
    /// <param name="entity">Объект для обновления</param>
    void Update(TEntity entity);

    /// <summary>
    /// Удаляет объект
    /// </summary>
    /// <param name="entity">Объект для удаления</param>
    void Delete(TEntity entity);
}
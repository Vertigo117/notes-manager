namespace NotesManager.Domain.Repositories;

/// <summary>
/// Интерфейс для реализации паттерна UnitOfWork
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Сохранить изменения
    /// </summary>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции</returns>
    Task SaveChangesAsync(CancellationToken token = default);
}
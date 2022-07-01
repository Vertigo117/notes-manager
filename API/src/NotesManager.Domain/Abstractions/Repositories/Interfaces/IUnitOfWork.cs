namespace NotesManager.Domain.Abstractions.Repositories.Interfaces;

/// <summary>
/// Интерфейс для реализации паттерна UnitOfWork
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Асинхронно сохраняет изменения в контексте данных
    /// </summary>
    /// <param name="token">Токен отмены операции</param>
    /// <returns>Задача, которая содержит результат выполнения асинхронной операции</returns>
    Task SaveChangesAsync(CancellationToken token = default);
}
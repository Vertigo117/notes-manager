namespace NotesManager.Domain.Abstractions.Repositories.Interfaces;

/// <summary>
/// Компоновщик репозиториев, реализует паттерн UnitOfWork
/// </summary>
public interface IEntityRepositoryWrapper : IUnitOfWork
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public IUserEntityRepository UserRepository { get; }

    /// <summary>
    /// Репозиторий заметок
    /// </summary>
    public INoteEntityRepository NoteRepository { get; }
}
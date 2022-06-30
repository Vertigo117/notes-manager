using NotesManager.Domain.Entities;

namespace NotesManager.Domain.Repositories;

/// <summary>
/// Компоновщик репозиториев, реализует паттерн UnitOfWork
/// </summary>
public interface IEntityRepositoryWrapper : IUnitOfWork
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public IEntityRepository<UserEntity> UserRepository { get; }

    /// <summary>
    /// Репозиторий заметок
    /// </summary>
    public IEntityRepository<NoteEntity> NoteRepository { get; }
}
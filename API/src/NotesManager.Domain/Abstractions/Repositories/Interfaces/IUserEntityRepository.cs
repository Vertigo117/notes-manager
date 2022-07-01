using NotesManager.Domain.Entities;

namespace NotesManager.Domain.Abstractions.Repositories.Interfaces;

/// <summary>
/// Репозиторий для доступа к данным сущности <see cref="UserEntity"/>
/// </summary>
public interface IUserEntityRepository : IEntityRepository<UserEntity>
{
}
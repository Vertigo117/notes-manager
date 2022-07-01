using NotesManager.Domain.Abstractions.Repositories.Interfaces;
using NotesManager.Domain.Entities;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <summary>
/// Репозиторий пользователей
/// </summary>
internal sealed class UserEntityRepository : EntityRepositoryBase<UserEntity>, IUserEntityRepository
{
    public UserEntityRepository(NotesManagerDbContext dbContext) : base(dbContext)
    {
    }
}
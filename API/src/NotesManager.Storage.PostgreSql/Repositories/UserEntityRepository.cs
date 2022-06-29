using NotesManager.Domain.Entities;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <summary>
/// Репозиторий пользователей
/// </summary>
internal class UserEntityRepository : EntityRepositoryBase<UserEntity>
{
    public UserEntityRepository(NotesManagerDbContext dbContext) : base(dbContext)
    {
    }
}
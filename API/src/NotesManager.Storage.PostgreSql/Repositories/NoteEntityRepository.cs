using NotesManager.Domain.Entities;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <summary>
/// Репозиторий заметок
/// </summary>
internal class NoteEntityRepository : EntityRepositoryBase<NoteEntity>
{
    public NoteEntityRepository(NotesManagerDbContext dbContext) : base(dbContext)
    {
    }
}
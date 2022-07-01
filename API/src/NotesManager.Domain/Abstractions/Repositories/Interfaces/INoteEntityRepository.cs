using NotesManager.Domain.Entities;

namespace NotesManager.Domain.Abstractions.Repositories.Interfaces;

/// <summary>
/// Репозиторий для доступа к данным сущности <see cref="NoteEntity"/>
/// </summary>
public interface INoteEntityRepository : IEntityRepository<NoteEntity>, IPagedEntityRepository<NoteEntity>
{
    
}
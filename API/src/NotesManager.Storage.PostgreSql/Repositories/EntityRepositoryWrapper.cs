using NotesManager.Domain.Entities;
using NotesManager.Domain.Repositories;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <inheritdoc/>
internal class EntityRepositoryWrapper : IEntityRepositoryWrapper
{
    private readonly NotesManagerDbContext _dbContext;

    private readonly Lazy<IEntityRepository<UserEntity>> _lazyUserRepository;
    private readonly Lazy<IEntityRepository<NoteEntity>> _lazyNoteRepository;

    public IEntityRepository<UserEntity> UserRepository => _lazyUserRepository.Value;
    public IEntityRepository<NoteEntity> NoteRepository => _lazyNoteRepository.Value;

    public EntityRepositoryWrapper(
        NotesManagerDbContext dbContext,
        IEntityRepository<UserEntity> userRepository,
        IEntityRepository<NoteEntity> noteRepository
    )
    {
        _dbContext = dbContext;
        _lazyUserRepository = new Lazy<IEntityRepository<UserEntity>>(() => userRepository);
        _lazyNoteRepository = new Lazy<IEntityRepository<NoteEntity>>(() => noteRepository);
    }

    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        await _dbContext.SaveChangesAsync(token);
    }
}
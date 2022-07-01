using NotesManager.Domain.Abstractions.Repositories.Interfaces;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <inheritdoc/>
internal class EntityRepositoryWrapper : IEntityRepositoryWrapper
{
    private readonly NotesManagerDbContext _dbContext;

    public IUserEntityRepository UserRepository { get; }

    public INoteEntityRepository NoteRepository { get; }

    public EntityRepositoryWrapper(
        NotesManagerDbContext dbContext,
        IUserEntityRepository userRepository,
        INoteEntityRepository noteRepository
    )
    {
        _dbContext = dbContext;
        UserRepository = userRepository;
        NoteRepository = noteRepository;
    }

    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        await _dbContext.SaveChangesAsync(token);
    }
}
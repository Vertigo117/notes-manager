using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NotesManager.Domain.Abstractions.Repositories.Interfaces;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Models;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <summary>
/// Репозиторий заметок
/// </summary>
internal sealed class NoteEntityRepository : EntityRepositoryBase<NoteEntity>, INoteEntityRepository
{
    public NoteEntityRepository(NotesManagerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<DataPage<NoteEntity>> GetPagedEntitiesByExpressionAsync(
        Expression<Func<NoteEntity, bool>> expression,
        int skip,
        int take
    )
    {
        var query = DbSet.Where(expression);
        var totalCount = await query.CountAsync();
        var notes = await query.OrderBy(entity => entity.CreationDate).Skip(skip).Take(take).ToListAsync();

        return new DataPage<NoteEntity>
        {
            TotalCount = totalCount,
            Data = notes
        };
    }
}
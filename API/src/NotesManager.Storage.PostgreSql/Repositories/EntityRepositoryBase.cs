using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Repositories;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <summary>
/// Базовая реализация репозитория
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
internal abstract class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly NotesManagerDbContext Context;

    protected EntityRepositoryBase(NotesManagerDbContext dbContext)
    {
        Context = dbContext;
    }

    public async Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Context.Set<TEntity>().Where(expression).ToListAsync();
    }

    public async Task<TEntity?> GetByIdOrDefaultAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public void Create(TEntity entity)
    {
        Context.Add(entity);
    }

    public void Update(TEntity entity)
    {
        Context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        Context.Remove(entity);
    }
}
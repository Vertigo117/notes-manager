using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NotesManager.Domain.Abstractions.Repositories.Interfaces;
using NotesManager.Domain.Entities;

namespace NotesManager.Storage.PostgreSql.Repositories;

/// <summary>
/// Базовая реализация репозитория
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
internal abstract class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// <see cref="DbSet{TEntity}"/> для формирования запросов к бд
    /// </summary>
    protected readonly DbSet<TEntity> DbSet;

    protected EntityRepositoryBase(NotesManagerDbContext dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
    }
    
    public void Create(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public async Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.Where(expression).ToListAsync();
    }

    public async Task<TEntity?> GetByIdOrDefaultAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }
}
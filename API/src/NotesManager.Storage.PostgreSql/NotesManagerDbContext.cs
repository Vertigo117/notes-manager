using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NotesManager.Domain.Entities;

namespace NotesManager.Storage.PostgreSql;

internal class NotesManagerDbContext : DbContext
{
    public const string SchemaName = "notes";

    /// <summary>
    /// Пользователи системы
    /// </summary>
    public DbSet<UserEntity> Users => Set<UserEntity>();

    /// <summary>
    /// Заметки
    /// </summary>
    public DbSet<NoteEntity> Notes => Set<NoteEntity>();

    public NotesManagerDbContext(DbContextOptions<NotesManagerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaName);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
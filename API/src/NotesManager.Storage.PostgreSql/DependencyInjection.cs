using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Repositories;
using NotesManager.Storage.PostgreSql.Repositories;

namespace NotesManager.Storage.PostgreSql;

/// <summary>
/// Методы расширений для инъекции зависимостей
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует зависимости для работы с бд
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> для регистрации сервисов</param>
    /// <param name="configuration"><see cref="IConfiguration"/> для доступа к конфигурации проекта</param>
    public static void AddPostgreSqlStorage(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(NotesManagerDbContext));
        
        services.AddDbContextPool<NotesManagerDbContext>(builder => builder.UseNpgsql(connectionString!,
            npgBuilder =>
                npgBuilder.MigrationsHistoryTable("__EFMigrationsHistory", NotesManagerDbContext.SchemaName)));

        services.AddScoped<IEntityRepository<NoteEntity>, NoteEntityRepository>();
        services.AddScoped<IEntityRepository<UserEntity>, UserEntityRepository>();
        services.AddScoped<IEntityRepositoryWrapper, EntityRepositoryWrapper>();
    }
}
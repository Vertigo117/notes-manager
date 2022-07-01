using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesManager.Domain.Abstractions.Repositories.Interfaces;
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

        services.AddScoped<INoteEntityRepository, NoteEntityRepository>();
        services.AddScoped<IUserEntityRepository, UserEntityRepository>();
        services.AddScoped<IEntityRepositoryWrapper, EntityRepositoryWrapper>();
    }
}
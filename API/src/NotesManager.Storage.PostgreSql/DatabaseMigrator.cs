using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NotesManager.Storage.PostgreSql;

/// <summary>
/// Содержит методы расширений для миграции данных
/// </summary>
public static class DatabaseMigrator
{
    /// <summary>
    /// Применить миграции
    /// </summary>
    /// <param name="serviceProvider"><see cref="IServiceProvider"/> для получения сервисов</param>
    public static async Task ApplyMigrations(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            await using var dbContext = scope.ServiceProvider.GetRequiredService<NotesManagerDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
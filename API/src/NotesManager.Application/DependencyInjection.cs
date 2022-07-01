using Microsoft.Extensions.DependencyInjection;
using NotesManager.Application.Abstractions.Services.Interfaces;
using NotesManager.Application.Services;

namespace NotesManager.Application;

/// <summary>
/// Методы расширений для инъекции зависимостей
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует зависимости, необходимые для сервисного слоя приложения
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> для регистрации сервисов</param>
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        services.AddScoped<INotesService, NotesService>();
    }
}
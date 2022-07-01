using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace NotesManager.Controllers;

/// <summary>
/// Методы расширений для инъекции зависимостей
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует контроллеры приложения
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> для регистрации зависимостей</param>
    public static void AddCustomControllers(this IServiceCollection services)
    {
        services.AddControllers().AddApplicationPart(Assembly.GetExecutingAssembly());
    }
}
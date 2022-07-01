using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace NotesManager.Web.Extensions;

/// <summary>
/// Расширение для интерфейса <see cref="IApplicationBuilder"/>
/// </summary>
public static class ApplicationBuilderExtension
{
    /// <summary>
    /// Регистрирует настроенный Swagger Middlware
    /// </summary>
    /// <param name="app">Пайплайн обработки запроса</param>
    public static void UseCustomSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
            
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
            
            options.RoutePrefix = "swagger";
            options.ConfigObject.DisplayRequestDuration = true;
            options.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
        });
    }
}
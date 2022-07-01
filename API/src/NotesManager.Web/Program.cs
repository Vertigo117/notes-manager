using Microsoft.AspNetCore.Mvc;
using NotesManager.Application;
using NotesManager.Controllers;
using NotesManager.Storage.PostgreSql;
using NotesManager.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomControllers();

builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "NotesManager.Contracts.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "NotesManager.Controllers.xml"),
        includeControllerXmlComments: true);
});

builder.Services.AddPostgreSqlStorage(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

await app.Services.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseCustomSwagger();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
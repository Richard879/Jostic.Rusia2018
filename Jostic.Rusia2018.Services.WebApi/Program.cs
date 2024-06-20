using Asp.Versioning.ApiExplorer;
using Jostic.Rusia2018.Application.UseCases;
using Jostic.Rusia2018.Persistence;
using Jostic.Rusia2018.Services.WebApi.Modules.Authentication;
using Jostic.Rusia2018.Services.WebApi.Modules.Feature;
using Jostic.Rusia2018.Services.WebApi.Modules.Injection;
using Jostic.Rusia2018.Services.WebApi.Modules.Swagger;
using Jostic.Rusia2018.Services.WebApi.Modules.Validator;
using Jostic.Rusia2018.Services.WebApi.Modules.Versioning;
using Jostic.Rusia2018.Services.WebApi.Modules.Redis;
using Jostic.Rusia2018.Services.WebApi.Modules.Middleware;
using Jostic.Rusia2018.Services.WebApi.Modules.RateLimiter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFeature(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddValidator();
//builder.Services.addWatchDog(builder.Configuration);
builder.Services.AddRedisCache(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // build a swagger endpoint for each discovered API version

        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}


//app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.AddMiddleware();
/*app.UseWatchDog(conf =>
{
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});*/

app.Run();

public partial class Program { };
using AccountOwnerServer.Extensions;
using AccountOwnerServer.Middleware;
using Microsoft.EntityFrameworkCore;
using NLog;
using Persistence;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

        // Add services to the container.

        builder.Services.ConfigureCors();
        builder.Services.ConfigureIISIntegration();
        builder.Services.ConfigureLoggerService();
        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            })
            .AddApplicationPart(typeof(AssemblyReference).Assembly);

        builder.Services.ConfigureSwaggerUI();

        builder.Services.ConfigureRepositoryWrapper();

        builder.Services.ConfigureSqlContext(builder.Configuration);

        builder.Services.ConfigureExceptionHandlingMiddleware();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.ConfigureSwaggerUI();
        }
        else
        {
            app.UseHsts();
        }

        //var logger = app.Services.GetRequiredService<ILoggerManager>();
        //app.ConfigureExceptionHandler(logger);
        //app.ConfigureCustomExceptionMiddleware();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
        });

        app.UseCors("CorsPolicy");

        app.UseAuthorization();

        app.MapControllers();

        await ApplyMigration(app.Services);

        await app.RunAsync();
    }

    private static async Task ApplyMigration(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        await using RepositoryDbContext dbContext = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
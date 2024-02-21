using AccountOwnerServer.Middleware;
using Domain.Entities;
using Domain.Helpers;
using Domain.Repositories;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Persistence;
using RepPersistence.Repositoriesository;
using Services;
using Services.Abstractions;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryDbContext>(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<ISortHelper<Owner>, SortHelper<Owner>>();

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureSwaggerUI(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void ConfigureExceptionHandlingMiddleware(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();
        }

    }
}

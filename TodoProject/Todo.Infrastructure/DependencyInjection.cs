using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Todo.ApplicationLayer.Repositories;
using Todo.Infrastructure.Persistance;
using Todo.Infrastructure.Repositories;

namespace Todo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration
        )
        {
            services.AddDbContext<ToDoDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            });
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<ITodoCommentRepository, TodoCommentRepository>();

            return services;
        }

        public static IServiceCollection AddHttpDatabaseLogging(this IServiceCollection services)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();

            services.AddHttpLogging(options =>
            {
                options.LoggingFields = HttpLoggingFields.All;
                options.RequestBodyLogLimit = 4096;
                options.ResponseBodyLogLimit = 4096;
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddNLog();
            });

            return services;
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using System.Text;
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

        public static WebApplicationBuilder UseLogging(this WebApplicationBuilder builder)
        {
            builder.Host.UseNLog();
            return builder;
        }

        public static IServiceCollection ConfigureLogging(this IServiceCollection services)
        {
            services.AddHttpLogging(options =>
            {
                options.LoggingFields = HttpLoggingFields.All;
                options.MediaTypeOptions.AddText("application/json", Encoding.UTF8);
            });

            return services;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
    }
}
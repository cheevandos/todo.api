using Microsoft.Extensions.DependencyInjection;
using Todo.ApplicationLayer.Services.Hashing;

namespace Todo.ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IHasher, MD5Hasher>();
            return services;
        }
    }
}
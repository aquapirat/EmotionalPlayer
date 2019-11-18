using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Player.Application.Common.Interfaces;

namespace Player.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlayerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PlayerDatabase")));

            services.AddScoped<IPlayerDbContext>(provider => provider.GetService<PlayerDbContext>());

            return services;
        }
    }
}

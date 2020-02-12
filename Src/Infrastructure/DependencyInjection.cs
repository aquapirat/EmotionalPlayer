using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Player.Application.Common.Interfaces;
using Player.Application.Common.Interfaces.BlobStorage;
using Player.Common;
using Player.Infrastructure.Blobs.AzureBlobStorage;
using Player.Infrastructure.Identity;
using Player.Infrastructure.Storage.AzureBlobStorage;
using Player.Infrastructure.Storage.AzureBlobStorage.Interfaces;

namespace Player.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.Configure<AzureBlobStorageCredentials>(configuration.GetSection("AzureBlobStorage").GetSection("Credentials"));

            services.AddScoped<IUserManager, UserManagerService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IBlobStorageService, AzureBlobStorageService>();
            services.AddTransient<IStorageNameGenerator, AzureBlobStorageNameGenerator>();
            services.AddTransient<IStorageAuthenticator, AzureBlobStorageAuthenticator>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PlayerDatabase")));

            return services;
        }
    }
}

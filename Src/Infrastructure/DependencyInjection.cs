using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddScoped<IUserManager, UserManagerService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IBlobStorageService, AzureBlobStorageService>();
            services.AddTransient<IStorageNameGenerator, AzureBlobStorageNameGenerator>();
            services.AddTransient<IStorageAuthenticator, AzureBlobStorageAuthenticator>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PlayerDatabase")));

            services.Configure<AzureBlobStorageCredentials>(configuration.GetSection("AzureBlobStorage__Credentials"));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            if (environment.IsEnvironment("Test") || environment.IsEnvironment("Docker"))
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                    {
                        options.Clients.Add(new Client
                        {
                            ClientId = "Player.IntegrationTests",
                            AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedScopes = { "Player.WebUIAPI", "openid", "profile" }
                        });
                    }).AddTestUsers(new List<TestUser>
                    {
                        new TestUser
                        {
                            SubjectId = "f26da293-02fb-4c90-be75-e4aa51e0bb17",
                            Username = "test@Player.com",
                            Password = "Player1!",
                            Claims = new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email, "test@Player.com")
                            }
                        }
                    });
            }
            else
            {
                services.AddIdentityServer()
                    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();
            }

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}

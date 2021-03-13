using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimaLabs.Foundation;

namespace UltimaLabs.Repository
{
    [PublicAPI]
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddUltimaLabsRepository(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            return services;
        }

        public static IHostBuilder ConfigureUltimaLabsRepository(this IHostBuilder builder) 
            => builder.ConfigureAppConfiguration(typeof(RepositoryExtensions).Assembly);
    }
}
using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimaLabs.Foundation;

namespace UltimaLabs.GraphQL
{
    [PublicAPI]
    public static class GraphQLExtensions
    {
        public static IServiceCollection AddUltimaLabsGraphQL(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            return services;
        }

        public static IHostBuilder ConfigureUltimaLabsGraphQL(this IHostBuilder builder) 
            => builder.ConfigureAppConfiguration(typeof(GraphQLExtensions).Assembly);
    }
}
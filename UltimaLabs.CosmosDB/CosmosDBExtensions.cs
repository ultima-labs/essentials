using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimaLabs.CosmosDB.Abstractions;
using UltimaLabs.CosmosDB.Operations;
using UltimaLabs.Foundation;

namespace UltimaLabs.CosmosDB
{
    [PublicAPI]
    public static class CosmosDBExtensions
    {
        public static IServiceCollection AddUltimaLabsCosmosDB(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddSingleton(typeof(IRetrieveOpFor<>), typeof(RetrieveOpFor<>));
            services.AddSingleton(typeof(IRetrieveOpFor<,>), typeof(RetrieveOpFor<,>));
            
            return services;
        }

        public static IHostBuilder ConfigureUltimaLabsCosmosDB(this IHostBuilder builder) 
            => builder.ConfigureAppConfiguration(typeof(CosmosDBExtensions).Assembly);
    }
}
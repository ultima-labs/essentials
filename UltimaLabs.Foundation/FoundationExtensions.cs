using System;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace UltimaLabs.Foundation
{
    [PublicAPI]
    public static class FoundationExtensions
    {
        public static IServiceCollection AddUltimaLabsFoundation(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            return services;
        }

        public static IHostBuilder ConfigureUltimaLabsFoundation(this IHostBuilder builder) 
            => builder.ConfigureAppConfiguration(typeof(FoundationExtensions).Assembly);

        public static IHostBuilder ConfigureAppConfiguration(this IHostBuilder builder, Assembly assembly)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            
            return builder.ConfigureAppConfiguration((context, config) =>
            {
                var name = assembly.GetName().Name;
                var location = Path.GetDirectoryName(assembly.Location);
                var provider = new PhysicalFileProvider(location);

                config
                    .AddJsonFile(provider, $"{name}.json", false, true)
                    .AddJsonFile(provider, $"{name}.{context.HostingEnvironment.EnvironmentName}.json", true, true)
                    .AddJsonFile(provider, $"{name}.{Environment.UserName}.json", true, true);
            });
        }
    }
}
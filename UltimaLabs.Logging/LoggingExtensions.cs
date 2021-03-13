using System;
using System.Reflection;
using JetBrains.Annotations;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace UltimaLabs.Logging
{
    [PublicAPI]
    public static class LoggingExtensions
    {
        public static IDisposable UseSerilog(
            Func<LoggerConfiguration, LoggerConfiguration>? afterAll = null,
            Func<LoggerConfiguration, LoggerConfiguration>? beforeAll = null)
        {
            afterAll ??= x => x;
            beforeAll ??= x => x;
            
            var urlSeq = Environment.GetEnvironmentVariable("ULTIMALABS_SEQ_URL")
                         ?? "http://localhost:5341/";

            var urlElastic = Environment.GetEnvironmentVariable("ULTIMALABS_ELASTICSEARCH_URL")
                             ?? "http://localhost:9200/";

            var configuration = new LoggerConfiguration();
            
            configuration = beforeAll(configuration);
            
            configuration = configuration
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                .MinimumLevel.Override("System", LogEventLevel.Debug)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", Assembly.GetEntryAssembly()?.GetName().Name)
                .WriteTo.Console()
                .WriteTo.Trace()
                .WriteTo.Seq(urlSeq)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(urlElastic))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7
                });
            
            configuration = afterAll(configuration);
            
            Log.Logger = configuration.CreateLogger();

            return new CloseAndFlush();
        }

        private sealed class CloseAndFlush : IDisposable
        {
            public void Dispose()
            {
                Log.CloseAndFlush();
            }
        }
    }
}
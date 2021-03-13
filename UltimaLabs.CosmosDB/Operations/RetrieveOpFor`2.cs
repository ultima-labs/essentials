using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using UltimaLabs.CosmosDB.Abstractions;
using IHaveID = UltimaLabs.Repository.Abstractions.IHaveID;

namespace UltimaLabs.CosmosDB.Operations
{
    internal sealed class RetrieveOpFor<TSource, TProjection> : IRetrieveOpFor<TSource, TProjection>
        where TSource: class, IHaveID, IHavePartitionKey
    {
        private readonly IServiceProvider _serviceProvider;

        public RetrieveOpFor([NotNull] IServiceProvider serviceProvider) 
            => _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        public async Task<TProjection> Retrieve(CosmosRetrieveOptions<TSource, TProjection> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            using var linked = CancellationTokenSource.CreateLinkedTokenSource(options.CancellationToken);
            try
            {
                var container = _serviceProvider.GetRequiredService<Container>();
                
                var id = options.ID;
                var partitionKey = new PartitionKey(options.PartitionKey);
                
                var item = await container.ReadItemAsync<TSource>(id, partitionKey, cancellationToken: linked.Token);

                return options.Projection(item);
            }
            finally
            {
                linked.Cancel();
            }
        }
    }
}
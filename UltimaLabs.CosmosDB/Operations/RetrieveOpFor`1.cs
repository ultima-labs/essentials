using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using UltimaLabs.CosmosDB.Abstractions;
using IHaveID = UltimaLabs.Repository.Abstractions.IHaveID;

namespace UltimaLabs.CosmosDB.Operations
{
    internal sealed class RetrieveOpFor<T> : IRetrieveOpFor<T>
        where T: class, IHaveID, IHavePartitionKey
    {
        private readonly IServiceProvider _serviceProvider;

        public RetrieveOpFor([NotNull] IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        public Task<T> Retrieve(CosmosRetrieveOptions<T, T> options) 
            => _serviceProvider.GetRequiredService<IRetrieveOpFor<T, T>>().Retrieve(options);

        public Task<T> Retrieve(CosmosRetrieveOptions<T> options)
            => _serviceProvider.GetRequiredService<IRetrieveOpFor<T, T>>().Retrieve(options);
    }
}
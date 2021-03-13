using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using UltimaLabs.CosmosDB.Abstractions;
using UltimaLabs.Repository.Abstractions;

namespace UltimaLabs.CosmosDB.Operations
{
    internal sealed class CreateOpFor<T> : ICreateOpFor<T>
        where T: class, IHaveID, IHavePartitionKey
    {
        private readonly IServiceProvider _serviceProvider;

        public CreateOpFor([NotNull] IServiceProvider serviceProvider) 
            => _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        public async Task<T> Create(CreateOptions<T> options)
        {
            var entity = options.Entity;
            var source = CancellationTokenSource.CreateLinkedTokenSource(options.CancellationToken);
            try
            {
                var hooks = _serviceProvider.GetService<IEnumerable<ICreateHook<T>>>();
                if (hooks != null)
                {
                    foreach (var hook in hooks)
                    {
                        entity = await hook.Hook(entity, source.Token);
                    }
                }
                
                if (options is CosmosCreateOptions<T> advanced)
                {
                }   
            }
            finally
            {
                source.Cancel();
            }

            throw new System.NotImplementedException();
        }

        public Task<T> Create(CosmosCreateOptions<T> options)
        {
            throw new NotImplementedException();
        }
    }
}
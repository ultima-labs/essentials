using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UltimaLabs.Repository.Abstractions;

namespace UltimaLabs.CosmosDB.Abstractions
{
    [PublicAPI]
    public static class CreateOpForExtensions
    {
        public static Task<T> Create<T>(this ICreateOpFor<T> self, T entity, CancellationToken cancellationToken)
            where T: class, IHaveID, IHavePartitionKey
            => self.Create(new CosmosCreateOptions<T>(entity)
            {
                CancellationToken = cancellationToken
            });
        
        public static Task CreateWithoutResponse<T>(this ICreateOpFor<T> self, T entity, CancellationToken cancellationToken)
            where T: class, IHaveID, IHavePartitionKey
            => self.Create(new CosmosCreateOptions<T>(entity)
            {
                CancellationToken = cancellationToken,
                NoResourceInResponse = true
            });
    }
}
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UltimaLabs.Repository.Abstractions;

namespace UltimaLabs.CosmosDB.Abstractions
{
    [PublicAPI]
    public static class RetrieveOpForExtensions
    {
        public static Task<T> Retrieve<T>(
            this IRetrieveOpFor<T> self,
            string id,
            string? partitionKey,
            CancellationToken cancellationToken)
            where T: class, IHaveID, IHavePartitionKey
            => self.Retrieve(new CosmosRetrieveOptions<T>(id)
            {
                PartitionKey = partitionKey,
                CancellationToken = cancellationToken
            });
    }
}
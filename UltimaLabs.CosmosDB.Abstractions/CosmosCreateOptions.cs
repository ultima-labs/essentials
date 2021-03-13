using JetBrains.Annotations;
using UltimaLabs.Repository.Abstractions;

namespace UltimaLabs.CosmosDB.Abstractions
{
    [PublicAPI]
    public sealed record CosmosCreateOptions<T> : CreateOptions<T>
        where T: class, IHaveID, IHavePartitionKey
    {
        public CosmosCreateOptions(T entity) 
            : base(entity)
        {
        }

        public string? PartitionKey => Entity.PartitionKey;

        public string? IfMatchETag { get; init; }
        
        public string? IfNoneMatchETag { get; init; }
        
        public bool NoResourceInResponse { get; init; }
    }
}
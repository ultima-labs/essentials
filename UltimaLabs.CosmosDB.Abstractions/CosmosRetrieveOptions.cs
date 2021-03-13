using JetBrains.Annotations;
using UltimaLabs.Repository.Abstractions;

namespace UltimaLabs.CosmosDB.Abstractions
{
    [PublicAPI]
    public record CosmosRetrieveOptions<TSource, TProjection> : RetrieveOptions<TSource, TProjection>
    {
        public CosmosRetrieveOptions(
            string id,
            ProjectionDelegate<TSource, TProjection> projection)
            : base(id, projection)
        {
        }
        
        public string? PartitionKey { get; init; }
    }
    
    [PublicAPI]
    public sealed record CosmosRetrieveOptions<T> : CosmosRetrieveOptions<T, T>
    {
        public CosmosRetrieveOptions(string id)
            : base(id, _ => _)
        {
        }
    }
}
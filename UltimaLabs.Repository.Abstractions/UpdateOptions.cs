using System.Threading;
using JetBrains.Annotations;

namespace UltimaLabs.Repository.Abstractions
{
    [PublicAPI]
    public record UpdateOptions<T>
    {
        public UpdateOptions(T entity) 
            => Entity = entity;

        public T Entity { get; init; }
        
        public CancellationToken CancellationToken { get; init; }
            = CancellationToken.None; 
    }
}
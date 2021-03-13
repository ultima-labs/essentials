using System.Threading;
using JetBrains.Annotations;

namespace UltimaLabs.Repository.Abstractions
{
    [PublicAPI]
    public record CreateOptions<T>
    {
        public CreateOptions(T entity) 
            => Entity = entity;

        public T Entity { get; init; }
        
        public CancellationToken CancellationToken { get; init; }
            = CancellationToken.None; 
    }
}
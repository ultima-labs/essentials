using System;
using System.Threading;
using JetBrains.Annotations;

namespace UltimaLabs.Repository.Abstractions
{
    [PublicAPI]
    public record RetrieveOptions<T, TProjection>
    {
        public RetrieveOptions(
            [NotNull] string id,
            [NotNull] ProjectionDelegate<T, TProjection> projection)
        {
            ID = id ?? throw new ArgumentNullException(nameof(id));
            Projection = projection ?? throw new ArgumentNullException(nameof(projection));
        }

        public string ID { get; }
        
        public ProjectionDelegate<T, TProjection> Projection { get; }

        public CancellationToken CancellationToken { get; init; }
            = CancellationToken.None; 
    }
}
using JetBrains.Annotations;

namespace UltimaLabs.Repository.Abstractions
{
    [PublicAPI]
    public delegate TProjection ProjectionDelegate<in TSource, out TProjection>(TSource source);
}
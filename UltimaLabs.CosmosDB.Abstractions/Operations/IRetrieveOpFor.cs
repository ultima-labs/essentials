using JetBrains.Annotations;
using UltimaLabs.Repository.Abstractions;

namespace UltimaLabs.CosmosDB.Abstractions
{
    [PublicAPI]
    public interface IRetrieveOpFor<T> : IRetrieveOpFor<T, T>, IRetrieveOpFor<T, T, CosmosRetrieveOptions<T>>
        where T: class, IHaveID, IHavePartitionKey
    {
    }

    [PublicAPI]
    public interface IRetrieveOpFor<TSource, TProjection> : IRetrieveOpFor<TSource, TProjection, CosmosRetrieveOptions<TSource, TProjection>>
        where TSource: class, IHaveID, IHavePartitionKey
    {
    }
}
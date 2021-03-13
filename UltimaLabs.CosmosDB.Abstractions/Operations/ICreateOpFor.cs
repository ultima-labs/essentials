using UltimaLabs.Repository.Abstractions;

namespace UltimaLabs.CosmosDB.Abstractions
{
    public interface ICreateOpFor<T> : ICreateOpFor<T, CosmosCreateOptions<T>>
        where T: class, IHaveID, IHavePartitionKey
    {
    }
}
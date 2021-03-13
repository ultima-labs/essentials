using System.Threading;
using System.Threading.Tasks;

namespace UltimaLabs.CosmosDB.Abstractions
{
    public interface ICreateHook<T>
    {
        public Task<T> Hook(T entity, CancellationToken cancellationToken);
    }
}
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace UltimaLabs.Repository.Abstractions
{
    [PublicAPI]
    public interface IRetrieveOpFor<TSource, TProjection, in TOptions>
        where TSource: class, IHaveID
        where TOptions: RetrieveOptions<TSource, TProjection>
    {
        Task<TProjection> Retrieve(TOptions options);
    }
    
    [PublicAPI]
    public interface IRetrieveOpFor<T, in TOptions> : IRetrieveOpFor<T, T, TOptions>
        where T: class, IHaveID
        where TOptions: RetrieveOptions<T, T>
    {
    }
}
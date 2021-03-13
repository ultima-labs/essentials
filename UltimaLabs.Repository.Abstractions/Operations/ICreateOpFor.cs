using System.Threading.Tasks;

namespace UltimaLabs.Repository.Abstractions
{
    public interface ICreateOpFor<T, in TOptions>
        where T: class, IHaveID
        where TOptions: CreateOptions<T>
    {
        Task<T> Create(TOptions options);
    }
}
using System.Threading.Tasks;

namespace UltimaLabs.Repository.Abstractions
{
    public interface IUpdateOpFor<T, in TOptions>
        where T: class, IHaveID
        where TOptions: UpdateOptions<T>
    {
        Task<T> Update(TOptions options);
    }
}
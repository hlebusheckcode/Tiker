using Tiker.Models;

namespace Tiker.Repositories
{
    public interface IAsyncRepository<T>
        where T : IEntity
    {
        Task<IEnumerable<T>> Read();
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<T> Delete(Guid id);
    }

    public interface IAsyncRepository<T, TFilter> : IAsyncRepository<T>
        where T : IEntity
        where TFilter : class
    {
        Task<IEnumerable<T>> Read(TFilter filter);
    }
}

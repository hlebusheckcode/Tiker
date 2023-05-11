using Tiker.Models;

namespace Tiker.Repositories.EntityFramework
{
    public abstract class AsyncRepository<T> : IAsyncRepository<T>
        where T : IEntity
    {
        public AsyncRepository(DataContext context)
        {
            Context = context;
        }

        public abstract Task<IEnumerable<T>> Read();
        public abstract Task<T> Create(T item);
        public abstract Task<T> Update(T item);
        public abstract Task<T> Delete(Guid id);

        protected DataContext Context { get; }
    }

    public abstract class AsyncRepository<T, TFilter> : AsyncRepository<T>, IAsyncRepository<T, TFilter>
        where T : IEntity
        where TFilter : class
    {
        public AsyncRepository(DataContext context)
            : base(context)
        {
        
        }

        public abstract Task<IEnumerable<T>> Read(TFilter filter);
    }
}

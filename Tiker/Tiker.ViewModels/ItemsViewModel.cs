using System.Diagnostics.CodeAnalysis;
using Tiker.Models;
using Tiker.Repositories;

namespace Tiker.ViewModels
{
    public class ItemsViewModel<T>
        where T : IEntity
    {
        public ItemsViewModel(IAsyncRepository<T> repository)
        {
            Repository = repository;
        }

        protected virtual IAsyncRepository<T> Repository { get; }
    }

    public class ItemsViewModel<T, TFilter> : ItemsViewModel<T>
        where T : IEntity
        where TFilter : class, new()
    {
        public ItemsViewModel(IAsyncRepository<T, TFilter> repository)
            : base(repository)
        {
        
        }

        protected override IAsyncRepository<T, TFilter> Repository { get; } = null!;
    }
}

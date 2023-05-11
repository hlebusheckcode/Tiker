using Microsoft.EntityFrameworkCore;
using Tiker.Models;

namespace Tiker.Repositories.EntityFramework
{
    public class TikTypeGroupRepository : AsyncRepository<TikTypeGroup>, ITikTypeGroupRepository
    {
        public TikTypeGroupRepository(DataContext context)
            : base(context)
        {
        
        }

        public override async Task<IEnumerable<TikTypeGroup>> Read()
        {
            return await Context.TikTypeGroups.ToArrayAsync();
        }

        public override async Task<TikTypeGroup> Create(TikTypeGroup item)
        {
            _ = await Context.TikTypeGroups.AddAsync(item);
            _ = await Context.SaveChangesAsync();
            return item;
        }

        public override async Task<TikTypeGroup> Update(TikTypeGroup item)
        {
            _ = Context.TikTypeGroups.Update(item);
            _ = await Context.SaveChangesAsync();
            return item;
        }

        public override async Task<TikTypeGroup> Delete(Guid id)
        {
            if (await Context.TikTypeGroups.FirstOrDefaultAsync(i => i.Id.Equals(id))
                is TikTypeGroup item)
            {
                _ = Context.TikTypeGroups.Remove(item);
                _ = await Context.SaveChangesAsync();
                return item;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(id));
        }
    }
}

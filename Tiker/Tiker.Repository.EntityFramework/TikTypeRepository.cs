using Microsoft.EntityFrameworkCore;
using Tiker.Models;

namespace Tiker.Repositories.EntityFramework
{
    public class TikTypeRepository : AsyncRepository<TikType, TikTypeFilter>, ITikTypeRepository
    {
        public TikTypeRepository(DataContext context)
            : base(context)
        {

        }

        public override async Task<IEnumerable<TikType>> Read(TikTypeFilter filter)
        {
            return await Context.TikTypes
                .Where(i => i.GroupId.Equals(filter.GroupId))
                .ToArrayAsync();
        }

        public override async Task<IEnumerable<TikType>> Read()
        {
            return await Context.TikTypes.ToArrayAsync();
        }

        public override async Task<TikType> Create(TikType item)
        {
            _ = await Context.TikTypes.AddAsync(item);
            _ = await Context.SaveChangesAsync();
            return item;
        }

        public override async Task<TikType> Update(TikType item)
        {
            _ = Context.TikTypes.Update(item);
            _ = await Context.SaveChangesAsync();
            return item;
        }

        public override async Task<TikType> Delete(Guid id)
        {
            if (await Context.TikTypes.FirstOrDefaultAsync(i => i.Id.Equals(id))
                is TikType item)
            {
                _ = Context.TikTypes.Remove(item);
                _ = await Context.SaveChangesAsync();
                return item;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(id));
        }
    }
}

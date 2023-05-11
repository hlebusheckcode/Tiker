using Microsoft.EntityFrameworkCore;
using Tiker.Models;

namespace Tiker.Repositories.EntityFramework
{
    public class TikRepository : AsyncRepository<Tik, TikFilter>, ITikRepository
    {
        public TikRepository(DataContext context)
            : base(context)
        {

        }

        public override async Task<IEnumerable<Tik>> Read(TikFilter filter)
        {
            return await Context.Tiks
                .Where(i => i.TypeId.Equals(filter.TypeId))
                .ToArrayAsync();
        }

        public override async Task<IEnumerable<Tik>> Read()
        {
            return await Context.Tiks.ToArrayAsync();
        }

        public override async Task<Tik> Create(Tik item)
        {
            _ = await Context.Tiks.AddAsync(item);
            _ = await Context.SaveChangesAsync();
            return item;
        }

        public override async Task<Tik> Update(Tik item)
        {
            _ = Context.Tiks.Update(item);
            _ = await Context.SaveChangesAsync();
            return item;
        }

        public override async Task<Tik> Delete(Guid id)
        {
            if (await Context.Tiks.FirstOrDefaultAsync(i => i.Id.Equals(id))
                is Tik item)
            {
                _ = Context.Tiks.Remove(item);
                _ = await Context.SaveChangesAsync();
                return item;
            }
            else
                throw new ArgumentOutOfRangeException(nameof(id));
        }
    }
}

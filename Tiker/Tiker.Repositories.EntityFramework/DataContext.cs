using Microsoft.EntityFrameworkCore;
using Tiker.Models;

namespace Tiker.Repositories.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<Tik> Tiks => Set<Tik>();
        public DbSet<TikType> TikTypes => Set<TikType>();
        public DbSet<TikTypeGroup> TikTypeGroups => Set<TikTypeGroup>();
    }
}

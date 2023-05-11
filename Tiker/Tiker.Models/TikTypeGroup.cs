namespace Tiker.Models
{
    public class TikTypeGroup : Entity
    {
        public required string Name { get; set; }

        public virtual IEnumerable<TikType> Types { get; set; } = null!;

        public override string ToString() => Name;
    }
}

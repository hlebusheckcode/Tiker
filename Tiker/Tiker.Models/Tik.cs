namespace Tiker.Models
{
    public class Tik : Entity
    {
        public required Guid TypeId { get; set; }
        public required DateTime Time { get; set; }

        public virtual TikType Type { get; set; } = null!;

        public override string ToString() => Time.ToString("g");
    }
}

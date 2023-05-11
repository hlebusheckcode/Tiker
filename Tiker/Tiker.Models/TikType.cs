namespace Tiker.Models
{
    public class TikType : Entity
    {
        public Guid? GroupId { get; set; }
        public required string Name { get; set; }

        public virtual TikTypeGroup? Group { get; set; }
        public virtual IEnumerable<Tik> Tiks { get; set; } = null!;

        public override string ToString() => Name;
    }
}

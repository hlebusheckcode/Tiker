namespace Tiker.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }

    public class Entity : IEntity
    {
        public required Guid Id { get; set; }
    }
}

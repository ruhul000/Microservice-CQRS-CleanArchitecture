namespace Domain.Primitives;

public abstract class Entity
{
    protected Entity(Guid id) => Id = id;
    public Entity()
    {
    }
    public Guid Id { get; protected set; }
}

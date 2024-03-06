namespace Sources.Client.DomainInterfaces.Entities
{
    public interface IEntity
    {
        int Id { get; }
        IEntityType EntityType { get; }
    }
}
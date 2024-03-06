using Sources.Client.DomainInterfaces.Entities;

namespace Sources.Client.InfrastructureInterfaces.Repositories
{
    public interface IEntityRepository
    {
        void Add(IEntity entity);
        IEntity Get(int id);
    }
}
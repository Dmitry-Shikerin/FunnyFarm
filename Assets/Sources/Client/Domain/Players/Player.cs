using Sources.Client.Domain.Composites;
using Sources.Client.DomainInterfaces.Entities;

namespace Sources.Client.Domain.Players
{
    //TODO сделать компонентом или как отдельная модель?
    public class Player : Composite, IEntity, IEntityType
    {
        public Player(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public IEntityType EntityType => this;
    }
}
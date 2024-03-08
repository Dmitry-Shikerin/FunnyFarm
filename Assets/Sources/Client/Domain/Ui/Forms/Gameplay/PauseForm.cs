using Sources.Client.Domain.Composites;
using Sources.Client.DomainInterfaces.Entities;
using Sources.Client.DomainInterfaces.Ui.Forms;

namespace Sources.Client.Domain.Ui.Forms.Gameplay
{
    public class PauseForm : Composite, IEntity, IEntityType, IForm
    {
        public PauseForm(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public IEntityType EntityType => this;
    }
}
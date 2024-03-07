using Sources.Client.Domain.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;

namespace Sources.Client.UseCases.Common.Components.Visibilities.Commands
{
    public class HideCommand : ComponentUseCaseBase<VisibilityComponent>
    {
        public HideCommand(IEntityRepository entityRepository) : base(entityRepository)
        {
        }

        public void Handle(int id) => 
            GetComponent(id).Show();
    }
}
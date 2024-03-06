using Sources.Client.Domain.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using UnityEngine;

namespace Sources.Client.UseCases.Common.Components.Positions.Commands
{
    public class SetPositionCommand : ComponentUseCaseBase<PositionComponent>
    {
        public SetPositionCommand(IEntityRepository entityRepository) : base(entityRepository)
        {
        }

        public void Handle(int id, Vector3 position) => 
            GetComponent(id).Set(position);
    }
}
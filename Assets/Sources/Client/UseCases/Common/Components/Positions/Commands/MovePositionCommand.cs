using Sources.Client.Domain.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using UnityEngine;

namespace Sources.Client.UseCases.Common.Components.Positions.Commands
{
    public class MovePositionCommand : ComponentUseCaseBase<PositionComponent>
    {
        public MovePositionCommand(IEntityRepository entityRepository) : base(entityRepository)
        {
        }

        public void Handle(int id, Vector3 moveDelta) => 
            GetComponent(id).Move(moveDelta);
    }
}
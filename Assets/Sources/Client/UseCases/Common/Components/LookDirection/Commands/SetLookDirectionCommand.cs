using Sources.Client.Domain.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;
using UnityEngine;

namespace Sources.Client.UseCases.Common.Components.LookDirection.Commands
{
    public class SetLookDirectionCommand : ComponentUseCaseBase<LookDirectionComponent>
    {
        public SetLookDirectionCommand(IEntityRepository entityRepository) : base(entityRepository)
        {
        }

        public void Handle(int id, Vector3 lookDirection) => 
            GetComponent(id).Set(lookDirection);
    }
}
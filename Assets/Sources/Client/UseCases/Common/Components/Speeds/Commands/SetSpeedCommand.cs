using Sources.Client.Domain.Components;
using Sources.Client.InfrastructureInterfaces.Repositories;

namespace Sources.Client.UseCases.Common.Components.Speeds.Commands
{
    public class SetSpeedCommand : ComponentUseCaseBase<SpeedComponent>
    {
        public SetSpeedCommand(IEntityRepository entityRepository) : base(entityRepository)
        {
        }

        public void Handle(int id, float value) => 
            GetComponent(id).Set(value);
    }
}
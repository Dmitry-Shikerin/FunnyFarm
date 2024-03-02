using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines.States
{
    public interface IState : IEnterable, IExitable, IUpdatable, ILateUpdatable, IFixedUpdatable
    {
    }
}
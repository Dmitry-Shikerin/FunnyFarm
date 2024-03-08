using Sources.Client.Infrastructure.StateMachines.ContextStateMachines;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.InfrastructureInterfaces.Services.Updates;
using Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines.States;

namespace Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.States
{
    public interface IContextState : IExitable, IEnterable, IUpdatable
    {
        void Apply(IContext context, IContextStateChanger contextStateMachine);
    }
}
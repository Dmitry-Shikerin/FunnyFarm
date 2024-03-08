using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Transitions
{
    public interface IContextTransition
    {
        IContextState NextState { get; }
        
        bool CanTransit(IContext context);
    }
}
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;

namespace Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines
{
    public interface IContextStateMachine
    {
        void Apply(IContext context);
    }
}
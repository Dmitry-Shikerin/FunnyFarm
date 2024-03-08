using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines
{
    public interface IContextStateChanger
    {
        void ChangeState(IContextState state);
    }
}
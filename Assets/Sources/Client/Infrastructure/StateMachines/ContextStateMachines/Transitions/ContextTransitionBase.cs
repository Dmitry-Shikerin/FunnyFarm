using System;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Transitions;

namespace Sources.Client.Infrastructure.StateMachines.ContextStateMachines.Transitions
{
    public abstract class ContextTransitionBase : IContextTransition
    {
        protected ContextTransitionBase(IContextState nextState)
        {
            NextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
        }

        public IContextState NextState { get; }

        public abstract bool CanTransit(IContext context);
    }
}
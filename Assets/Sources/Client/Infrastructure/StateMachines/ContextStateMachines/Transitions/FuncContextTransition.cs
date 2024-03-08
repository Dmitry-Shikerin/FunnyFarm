using System;
using ModestTree.Util;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Client.Infrastructure.StateMachines.ContextStateMachines.Transitions
{
    public class FuncContextTransition : ContextTransitionBase
    {
        private readonly Func<IContext, bool> _condition;

        public FuncContextTransition(IContextState nextState, Func<IContext, bool> condition) : base(nextState)
        {
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
        }

        public override bool CanTransit(IContext context) => 
            _condition.Invoke(context);
    }
}
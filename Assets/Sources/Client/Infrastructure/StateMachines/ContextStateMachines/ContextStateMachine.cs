using System;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.Client.Infrastructure.StateMachines.ContextStateMachines
{
    public class ContextStateMachine : IContextStateMachine, IContextStateChanger, IUpdatable
    {
        private IContextState _currentState;
        private bool _isRunning;

        public ContextStateMachine(IContextState firstState)
        {
            _currentState = firstState ?? throw new ArgumentNullException(nameof(firstState));
        }

        public void Run()
        {
            if(_isRunning)
                return;
            
            _currentState.Enter();
            _isRunning = true;
        }

        public void Stop()
        {
            if(_isRunning == false)
                return;
            
            _currentState?.Exit();
            _isRunning = false;
        }

        public void ChangeState(IContextState state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState?.Enter();
        }
        
        public void Apply(IContext context)
        {
            _currentState?.Apply(context, this);
        }

        public void Update(float deltaTime)
        {
            _currentState?.Update(deltaTime);
        }
    }
}
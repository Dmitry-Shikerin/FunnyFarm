using System;
using Sources.Client.Infrastructure.StateMachines.ContextStateMachines;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;

namespace Sources.Client.Controllers.StateMachines.Players.PlayerMovements
{
    public class PlayerMovementStateMachine : ContextStateMachine
    {
        private readonly IInputService _inputService;

        public PlayerMovementStateMachine
        (
            
            IInputService inputService,
            IContextState firstState
        ) : base(firstState)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public void OnUpdate(float deltaTime)
        {
            Apply(_inputService.PlayerInput);
            Update(deltaTime);
        }
    }
}
using System;
using Sources.Client.Controllers.StateMachines.Players.PlayerMovements;
using Sources.Client.Controllers.StateMachines.Players.PlayerMovements.States;
using Sources.Client.Domain.Dtos;
using Sources.Client.Infrastructure.StateMachines.ContextStateMachines;
using Sources.Client.Infrastructure.StateMachines.ContextStateMachines.Transitions;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.SignalBuses.Interfaces;

namespace Sources.Client.Infrastructure.Factories.Controllers.ContextStateMachines
{
    public class PlayerMovementStateMachineFactory
    {
        private readonly IInputService _inputService;
        private readonly ISignalBus _signalBus;
        private readonly ICurrentPlayerService _currentPlayerService;
        private readonly GetPositionQuery _getPositionQuery;
        private readonly GetSpeedQuery _getSpeedQuery;

        public PlayerMovementStateMachineFactory
        (
            IInputService inputService,
            ISignalBus signalBus,
            ICurrentPlayerService currentPlayerService,
            GetPositionQuery getPositionQuery,
            GetSpeedQuery getSpeedQuery
        )
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));
            _currentPlayerService =
                currentPlayerService ?? throw new ArgumentNullException(nameof(currentPlayerService));
            _getPositionQuery = getPositionQuery ?? throw new ArgumentNullException(nameof(getPositionQuery));
            _getSpeedQuery = getSpeedQuery ?? throw new ArgumentNullException(nameof(getSpeedQuery));
        }

        public PlayerMovementStateMachine Create()
        {
            //TODO в целом их можно зарегистрировать
            PlayerIdleState idleState = new PlayerIdleState
            (
                _inputService,
                _signalBus,
                _currentPlayerService,
                _getPositionQuery,
                _getSpeedQuery
            );
            PlayerRunState runState = new PlayerRunState
            (
                _inputService,
                _signalBus,
                _currentPlayerService,
                _getPositionQuery,
                _getSpeedQuery
            );

            //TODO придумать запись получше
            FuncContextTransition toRunTransition = new FuncContextTransition(
                runState, (context) =>
                {
                    if (context is not PlayerInput playerInput)
                        return false;

                    if (playerInput.Direction.magnitude < 0.1f)
                        return false;

                    return true;
                });
            idleState.AddTransition(toRunTransition);

            FuncContextTransition toIdleTransition = new FuncContextTransition(
                idleState, (context) =>
                {
                    if (context is not PlayerInput playerInput)
                        return false;

                    if (playerInput.Direction.magnitude > 0.1f)
                        return false;

                    return true;
                });
            runState.AddTransition(toIdleTransition);

            return new PlayerMovementStateMachine(_inputService, idleState);
        }
    }
}
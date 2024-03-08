using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.LiveData;
using Sources.Frameworks.SignalBuses.Interfaces;
using UnityEngine;

namespace Sources.Client.Controllers.StateMachines.Players.PlayerMovements.States.Common
{
    public class PlayerMovementStateBase : ContextStateBase
    {
        protected readonly IInputService InputService;

        private readonly ISignalBus _signalBus;
        private readonly ICurrentPlayerService _currentPlayerService;
        private readonly GetPositionQuery _getPositionQuery;
        private readonly GetSpeedQuery _getSpeedQuery;

        private LiveData<Vector3> _position;
        private LiveData<float> _speed;

        protected readonly float SpeedDelta = 5f;

        private Vector3 _direction;

        protected float CurrentSpeed;
        protected Vector3 Destination;

        public PlayerMovementStateBase
        (
            IInputService inputService,
            ISignalBus signalBus,
            ICurrentPlayerService currentPlayerService,
            GetPositionQuery getPositionQuery,
            GetSpeedQuery getSpeedQuery
        )
        {
            InputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));
            _currentPlayerService =
                currentPlayerService ?? throw new ArgumentNullException(nameof(currentPlayerService));
            _getPositionQuery = getPositionQuery ?? throw new ArgumentNullException(nameof(getPositionQuery));
            _getSpeedQuery = getSpeedQuery ?? throw new ArgumentNullException(nameof(getSpeedQuery));
        }

        //TODO пришлось сделать так изза провайдера
        protected LiveData<Vector3> Position => _position ??=
            _getPositionQuery.Handle(_currentPlayerService.CharacterId);

        protected LiveData<float> Speed => _speed ??=
            _getSpeedQuery.Handle(_currentPlayerService.CharacterId);

        protected void Handle(Vector3 moveDelta)
        {
            _signalBus.Handle(new PlayerRotateSignal(moveDelta));
            _signalBus.Handle(new PlayerMoveSignal(moveDelta));
        }

        protected void SetSpeed(float speed)
        {
            CurrentSpeed = Mathf.Clamp(speed, 0, 1);
            _signalBus.Handle(new PlayerSpeedSignal(CurrentSpeed));
        }
    }
}
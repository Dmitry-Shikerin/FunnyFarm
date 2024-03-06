using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.Services.MovementServices;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.LiveData;
using Sources.Frameworks.SignalBuses.Interfaces;
using UnityEngine;

namespace Sources.Client.Infrastructure.Services.MovementService
{
    public class PlayerMovementService : IPlayerMovementService
    {
        private readonly IInputService _inputService;
        private readonly ISignalBus _signalBus;
        private readonly ICurrentPlayerService _currentPlayerService;
        private readonly GetPositionQuery _getPositionQuery;
        private readonly GetSpeedQuery _getSpeedQuery;
        private LiveData<Vector3> _position;
        private LiveData<float> _speed;

        private readonly float _speedDelta = 5f;

        private Vector3 _direction;
        
        private float _currentSpeed;
        private Vector3 _destination;

        public PlayerMovementService
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
            _currentPlayerService = currentPlayerService ?? throw new ArgumentNullException(nameof(currentPlayerService));
            _getPositionQuery = getPositionQuery ?? throw new ArgumentNullException(nameof(getPositionQuery));
            _getSpeedQuery = getSpeedQuery ?? throw new ArgumentNullException(nameof(getSpeedQuery));
            //TODO берем свойства из модели игрока?
            //TODO походу важен порядок инициализации
            // _position = getPositionQuery.Handle(currentPlayerService.CharacterId);
            // _speed = getSpeedQuery.Handle(currentPlayerService.CharacterId);
        }

        //TODO пришлось сделать так изза провайдера
        private LiveData<Vector3> Position => _position ??= 
            _getPositionQuery.Handle(_currentPlayerService.CharacterId);
        private LiveData<float> Speed => _speed ??= 
            _getSpeedQuery.Handle(_currentPlayerService.CharacterId);
        
        //TODO правильно ли?
        private bool IsMoving => _inputService.PlayerInput.Direction.magnitude > 0.01f;
        
        public void Update(float deltaTime)
        {
            if (IsMoving)
            {
                Vector3 moveDelta = Speed.Value * Time.deltaTime *
                                    _inputService.PlayerInput.Direction.normalized;

                _signalBus.Handle(new PlayerRotateSignal(moveDelta));
                _signalBus.Handle(new PlayerMoveSignal(moveDelta));

                SetSpeed(_currentSpeed + _speedDelta * Time.deltaTime);
            }
            else
            {
                SetSpeed(_currentSpeed - _speedDelta * Time.deltaTime);
            }
        }

        private void SetSpeed(float speed)
        {
            _currentSpeed = Mathf.Clamp(speed, 0, 1);
            _signalBus.Handle(new PlayerSpeedSignal(_currentSpeed));
        }

        // public void Update(float deltaTime)
        // {
        //     if (IsMoving)
        //     {
        //         Vector3 moveDelta = _speed.Value * Time.deltaTime *
        //                             _inputService.PlayerInput.Direction.normalized;
        //
        //         _signalBus.Handle(new PlayerRotateSignal(moveDelta));
        //         _signalBus.Handle(new PlayerMoveSignal(moveDelta));
        //
        //         SetSpeed(_currentSpeed + _speedDelta * Time.deltaTime);
        //     }
        //     else
        //     {
        //         SetSpeed(_currentSpeed - _speedDelta * Time.deltaTime);
        //     }
        // }
        //
        // private void SetSpeed(float speed)
        // {
        //     _currentSpeed = Mathf.Clamp(speed, 0, 1);
        //     _signalBus.Handle(new PlayerSpeedSignal(_currentSpeed));
        // }
    }
}
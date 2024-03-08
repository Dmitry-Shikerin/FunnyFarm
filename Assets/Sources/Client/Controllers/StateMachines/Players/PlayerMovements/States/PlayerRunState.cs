﻿using Sources.Client.Controllers.StateMachines.Players.PlayerMovements.States.Common;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.SignalBuses.Interfaces;
using UnityEngine;

namespace Sources.Client.Controllers.StateMachines.Players.PlayerMovements.States
{
    public class PlayerRunState : PlayerMovementStateBase
    {
        public PlayerRunState
        (
            IInputService inputService,
            ISignalBus signalBus,
            ICurrentPlayerService currentPlayerService,
            GetPositionQuery getPositionQuery,
            GetSpeedQuery getSpeedQuery
        ) : base
        (
            inputService,
            signalBus,
            currentPlayerService,
            getPositionQuery,
            getSpeedQuery
        )
        {
        }

        public override void Enter(object payload = null)
        {
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            Vector3 moveDelta = Speed.Value * Time.deltaTime *
                                InputService.PlayerInput.Direction.normalized;

            Handle(moveDelta);
            SetSpeed(CurrentSpeed + SpeedDelta * Time.deltaTime);
        }
    }
}
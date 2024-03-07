using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.UseCases.Common.Components.Positions.Commands;
using Sources.Frameworks.SignalBuses.Interfaces.Actions.Generic;

namespace Sources.Client.Controllers.Actions.Players
{
    public class PlayerMoveSignalAction : ISignalAction<PlayerMoveSignal>
    {
        private readonly ICurrentPlayerService _currentPlayerService;
        private readonly MovePositionCommand _movePositionCommand;

        public PlayerMoveSignalAction
        (
            ICurrentPlayerService currentPlayerService,
            MovePositionCommand movePositionCommand
        )
        {
            _currentPlayerService = currentPlayerService ??
                                    throw new ArgumentNullException(nameof(currentPlayerService));
            _movePositionCommand = movePositionCommand ??
                                   throw new ArgumentNullException(nameof(movePositionCommand));
        }

        public void Handle(PlayerMoveSignal signal) => 
            _movePositionCommand.Handle(_currentPlayerService.CharacterId, signal.MoveDelta);
    }
}
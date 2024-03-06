using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.UseCases.Common.Components.Speeds.Commands;
using Sources.Frameworks.SignalBuses.Interfaces.Actions.Generic;

namespace Sources.Client.Controllers.Actions.Players
{
    public class PlayerSpeedSignalAction : ISignalAction<PlayerSpeedSignal>
    {
        private readonly ICurrentPlayerService _currentPlayerService;
        private readonly SetSpeedCommand _setSpeedCommand;

        public PlayerSpeedSignalAction
        (
            ICurrentPlayerService currentPlayerService,
            SetSpeedCommand setSpeedCommand
        )
        {
            _currentPlayerService =
                currentPlayerService ?? throw new ArgumentNullException(nameof(currentPlayerService));
            _setSpeedCommand = setSpeedCommand ?? throw new ArgumentNullException(nameof(setSpeedCommand));
        }

        public void Handle(PlayerSpeedSignal signal) =>
            _setSpeedCommand.Handle(_currentPlayerService.CharacterId, signal.Speed);
    }
}
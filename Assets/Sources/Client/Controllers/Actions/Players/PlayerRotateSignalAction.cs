using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.UseCases.Common.Components.LookDirection.Commands;
using Sources.Frameworks.SignalBuses.Interfaces.Actions.Generic;

namespace Sources.Client.Controllers.Actions.Players
{
    public class PlayerRotateSignalAction : ISignalAction<PlayerRotateSignal>
    {
        private readonly ICurrentPlayerService _currentPlayerService;
        private readonly SetLookDirectionCommand _lookDirectionCommand;

        public PlayerRotateSignalAction
        (
            ICurrentPlayerService currentPlayerService,
            SetLookDirectionCommand lookDirectionCommand
        )
        {
            _currentPlayerService = currentPlayerService ??
                                    throw new ArgumentNullException(nameof(currentPlayerService));
            _lookDirectionCommand = lookDirectionCommand ??
                                    throw new ArgumentNullException(nameof(lookDirectionCommand));
        }

        public void Handle(PlayerRotateSignal signal)
        {
            if (signal.LookDirection.magnitude < 0.01f)
                return;

            _lookDirectionCommand.Handle(_currentPlayerService.CharacterId, signal.LookDirection);
        }
    }
}
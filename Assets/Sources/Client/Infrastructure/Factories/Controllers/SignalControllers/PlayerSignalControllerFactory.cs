using System;
using Sources.Client.Controllers.Actions.Players;
using Sources.Frameworks.SignalBuses.Implementation;
using Sources.Frameworks.SignalBuses.Interfaces.Actions;

namespace Sources.Client.Infrastructure.Factories.Controllers.SignalControllers
{
    public class PlayerSignalControllerFactory
    {
        private readonly PlayerMoveSignalAction _playerMoveSignalAction;
        private readonly PlayerRotateSignalAction _playerRotateSignalAction;
        private readonly PlayerSpeedSignalAction _playerSpeedSignalAction;
        private readonly CreatePlayerSignalAction _createPlayerSignalAction;

        public PlayerSignalControllerFactory
        (
            PlayerMoveSignalAction playerMoveSignalAction,
            PlayerRotateSignalAction playerRotateSignalAction,
            PlayerSpeedSignalAction playerSpeedSignalAction,
            CreatePlayerSignalAction createPlayerSignalAction
        )
        {
            _playerMoveSignalAction = playerMoveSignalAction ?? 
                                      throw new ArgumentNullException(nameof(playerMoveSignalAction));
            _playerRotateSignalAction = playerRotateSignalAction ?? 
                                        throw new ArgumentNullException(nameof(playerRotateSignalAction));
            _playerSpeedSignalAction = playerSpeedSignalAction ?? 
                                       throw new ArgumentNullException(nameof(playerSpeedSignalAction));
            _createPlayerSignalAction = createPlayerSignalAction ?? 
                                        throw new ArgumentNullException(nameof(createPlayerSignalAction));
        }

        public SignalController Create()
        {
            return new SignalController
            (
                new ISignalAction[]
                {
                    _createPlayerSignalAction,
                    _playerMoveSignalAction,
                    _playerRotateSignalAction,
                    _playerSpeedSignalAction
                }
            );
        }
    }
}
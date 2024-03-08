using System;
using Cysharp.Threading.Tasks;
using Sources.Client.Controllers.Scenes;
using Sources.Client.Infrastructure.Factories.Controllers.ContextStateMachines;
using Sources.Client.Infrastructure.Factories.Services;
using Sources.Client.Infrastructure.Factories.Views.Scenes;
using Sources.Client.InfrastructureInterfaces.Factories.Scenes;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.Services.UpdateServices;
using Sources.ControllersInterfaces.Scenes;

namespace Sources.Client.Infrastructure.Factories.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly PlayerMovementStateMachineFactory _playerMovementStateMachineFactory;
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly PlayerMovementServiceFactory _playerMovementServiceFactory;
        private readonly GamePlaySceneViewFactory _gamePlaySceneViewFactory;

        public GameplaySceneFactory
        (
            PlayerMovementStateMachineFactory playerMovementStateMachineFactory,
            IUpdateService updateService,
            IInputService inputService,
            PlayerMovementServiceFactory playerMovementServiceFactory,
            GamePlaySceneViewFactory gamePlaySceneViewFactory
        )
        {
            _playerMovementStateMachineFactory = playerMovementStateMachineFactory ?? throw new ArgumentNullException(nameof(playerMovementStateMachineFactory));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _playerMovementServiceFactory = playerMovementServiceFactory ?? throw new ArgumentNullException(nameof(playerMovementServiceFactory));
            _gamePlaySceneViewFactory = gamePlaySceneViewFactory ?? throw new ArgumentNullException(nameof(gamePlaySceneViewFactory));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene
            (
                _playerMovementStateMachineFactory,
                _updateService,
                _inputService,
                _playerMovementServiceFactory.Create(),
                _gamePlaySceneViewFactory
            );
        }
    }
}
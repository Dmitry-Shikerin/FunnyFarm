using System;
using Sources.Client.Infrastructure.Factories.Views.Scenes;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.Services.MovementServices;
using Sources.ControllersInterfaces.Scenes;

namespace Sources.Client.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IInputService _inputService;
        private readonly IPlayerMovementService _playerMovementService;
        private readonly GamePlaySceneViewFactory _gamePlaySceneViewFactory;

        public GameplayScene
        (
            IInputService inputService,
            IPlayerMovementService playerMovementService,
            GamePlaySceneViewFactory gamePlaySceneViewFactory
        )
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _playerMovementService =
                playerMovementService ?? throw new ArgumentNullException(nameof(playerMovementService));
            _gamePlaySceneViewFactory = gamePlaySceneViewFactory ??
                                        throw new ArgumentNullException(nameof(gamePlaySceneViewFactory));
        }

        public string Name => nameof(GameplayScene);

        public void Enter(object payload)
        {
            _gamePlaySceneViewFactory.Create();
        }

        public void Exit()
        {
        }

        public void Update(float deltaTime)
        {
            _inputService.Update(deltaTime);
            _playerMovementService.Update(deltaTime);
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}
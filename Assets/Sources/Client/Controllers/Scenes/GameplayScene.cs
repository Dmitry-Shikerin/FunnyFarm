using System;
using Sources.Client.Controllers.StateMachines.Players.PlayerMovements;
using Sources.Client.Infrastructure.Factories.Controllers.ContextStateMachines;
using Sources.Client.Infrastructure.Factories.Services.FormServices;
using Sources.Client.Infrastructure.Factories.Views.Scenes;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.Services.MovementServices;
using Sources.Client.InfrastructureInterfaces.Services.UpdateServices;
using Sources.ControllersInterfaces.Scenes;

namespace Sources.Client.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly IPlayerMovementService _playerMovementService;
        private readonly GamePlaySceneViewFactory _gamePlaySceneViewFactory;
        private readonly PlayerMovementStateMachine _playerMovementStateMachine;

        public GameplayScene
        (
            PlayerMovementStateMachineFactory playerMovementStateMachineFactory,
            IUpdateService updateService,
            IInputService inputService,
            IPlayerMovementService playerMovementService,
            GamePlaySceneViewFactory gamePlaySceneViewFactory
        )
        {
            _playerMovementStateMachine = playerMovementStateMachineFactory.Create();
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
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
            _playerMovementStateMachine.Run();
        }

        public void Exit()
        {
            _playerMovementStateMachine.Stop();
        }

        public void Update(float deltaTime)
        {
            _updateService.Update(deltaTime);
            _inputService.Update(deltaTime);
            _playerMovementStateMachine.OnUpdate(deltaTime);
            // _playerMovementService.Update(deltaTime);
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}
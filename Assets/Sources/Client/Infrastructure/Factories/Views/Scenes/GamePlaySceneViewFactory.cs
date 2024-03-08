using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.Controllers.ViewModels.Uis.GameplayHud.Forms;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.Infrastructure.Factories.Controllers.SignalControllers;
using Sources.Client.Infrastructure.Factories.Services.FormServices;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.SignalBuses.Implementation;
using Sources.Frameworks.SignalBuses.Interfaces;
using Sources.Frameworks.SignalBuses.Interfaces.Handlers;
using UnityEngine;

namespace Sources.Client.Infrastructure.Factories.Views.Scenes
{
    public class GamePlaySceneViewFactory
    {
        private readonly IIdGenerator _idGenerator;
        private readonly ISignalBus _signalBus;
        private readonly ISignalHandlerRegisterer _signalHandlerRegisterer;
        private readonly PlayerSignalControllerFactory _playerSignalControllerFactory;
        private readonly GameplayFormServiceFactory _gameplayFormServiceFactory;

        public GamePlaySceneViewFactory
        (
            IIdGenerator idGenerator,
            ISignalBus signalBus,
            ISignalHandlerRegisterer signalHandlerRegisterer,
            PlayerSignalControllerFactory playerSignalControllerFactory,
            GameplayFormServiceFactory gameplayFormServiceFactory
        )
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));
            _signalHandlerRegisterer = signalHandlerRegisterer ?? throw new ArgumentNullException(nameof(signalHandlerRegisterer));
            _playerSignalControllerFactory = playerSignalControllerFactory ??
                                             throw new ArgumentNullException(nameof(playerSignalControllerFactory));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
        }

        public void Create()
        {
            SignalController playerSignalController = _playerSignalControllerFactory.Create();
            //TODO если список то прогнать форичем
            _signalHandlerRegisterer.Register(playerSignalController);
            _signalBus.Handle(new CreatePlayerSignal(new Vector3(0,0,0)));

            _gameplayFormServiceFactory
                .Create()
                .Show<HudForm>();
        }
    }
}
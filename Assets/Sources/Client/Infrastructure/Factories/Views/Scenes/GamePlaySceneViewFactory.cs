using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.Infrastructure.Factories.Controllers.SignalControllers;
using Sources.Client.Infrastructure.Services.IdGenerators;
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

        public GamePlaySceneViewFactory
        (
            IIdGenerator idGenerator,
            ISignalBus signalBus,
            ISignalHandlerRegisterer signalHandlerRegisterer,
            PlayerSignalControllerFactory playerSignalControllerFactory
        )
        {
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));
            _signalHandlerRegisterer = signalHandlerRegisterer ?? throw new ArgumentNullException(nameof(signalHandlerRegisterer));
            _playerSignalControllerFactory = playerSignalControllerFactory ??
                                             throw new ArgumentNullException(nameof(playerSignalControllerFactory));
        }

        public void Create()
        {
            SignalController playerSignalController = _playerSignalControllerFactory.Create();

            //TODO если список то прогнать форичем
            _signalHandlerRegisterer.Register(playerSignalController);
            
            _signalBus.Handle(new CreatePlayerSignal(new Vector3(0,0,0)));
        }
    }
}
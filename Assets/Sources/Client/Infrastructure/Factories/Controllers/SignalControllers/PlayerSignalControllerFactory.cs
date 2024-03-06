using System;
using Sources.Client.Controllers.Actions.Players;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Domain.Players;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Client.Infrastructure.Services.CurrentPlayers;
using Sources.Client.Infrastructure.Services.IdGenerators;
using Sources.Client.InfrastructureInterfaces.Factories.Domain;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.UseCases.Common.Components.LookDirection.Commands;
using Sources.Client.UseCases.Common.Components.Positions.Commands;
using Sources.Client.UseCases.Common.Components.Speeds.Commands;
using Sources.Client.UseCases.Queries.Players;
using Sources.Frameworks.MVVM.Infrastructure.Builders;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.SignalBuses.Implementation;
using Sources.Frameworks.SignalBuses.Interfaces;
using Sources.Frameworks.SignalBuses.Interfaces.Actions;

namespace Sources.Client.Infrastructure.Factories.Controllers.SignalControllers
{
    public class PlayerSignalControllerFactory
    {
        private readonly ISignalBus _signalBus;
        private readonly IBindableViewFactory _bindableViewFactory;
        private readonly IEntityRepository _entityRepository;
        private readonly IIdGenerator _idGenerator;
        private readonly IPlayerFactory _playerFactory;
        private readonly CurrentPlayerService _currentPlayerService;

        public PlayerSignalControllerFactory
        (
            ISignalBus signalBus,
            IBindableViewFactory bindableViewFactory,
            IEntityRepository entityRepository,
            IIdGenerator idGenerator,
            IPlayerFactory playerFactory,
            CurrentPlayerService currentPlayerService
        )
        {
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));
            _bindableViewFactory = bindableViewFactory ??
                                   throw new ArgumentNullException(nameof(bindableViewFactory));
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
            _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
            _currentPlayerService = currentPlayerService ??
                                    throw new ArgumentNullException(nameof(currentPlayerService));
        }

        public SignalController Create()
        {
            LookDirectionViewModelComponentFactory lookDirectionViewModelComponentFactory =
                new LookDirectionViewModelComponentFactory(_entityRepository);
            CharacterControllerMovementViewModelComponentFactory characterControllerMovementViewModelComponentFactory =
                new CharacterControllerMovementViewModelComponentFactory(_entityRepository);
            
            PlayerViewModelFactory playerViewModelFactory = new PlayerViewModelFactory
            (
                lookDirectionViewModelComponentFactory,
                characterControllerMovementViewModelComponentFactory
            );
            
            BindableViewBuilder<PlayerViewModel> playerViewBuilder = new BindableViewBuilder<PlayerViewModel>
            (
                _bindableViewFactory,
                playerViewModelFactory
            );
            
            CreateCurrentCharacterQuery createCurrentCharacterQuery = new CreateCurrentCharacterQuery
            (
                _entityRepository,
                _playerFactory,
                _idGenerator
            );

            CreatePlayerSignalAction createPlayerSignalAction = new CreatePlayerSignalAction
            (
                 _signalBus,
                 playerViewBuilder,
                 _currentPlayerService,
                 createCurrentCharacterQuery
            );

            //TODO засунуть в резолвер?
            MovePositionCommand movePositionCommand = new MovePositionCommand(_entityRepository);
            SetLookDirectionCommand setLookDirectionCommand = new SetLookDirectionCommand(_entityRepository);
            SetSpeedCommand setSpeedCommand = new SetSpeedCommand(_entityRepository);

            PlayerMoveSignalAction playerMoveSignalAction = new PlayerMoveSignalAction(
                _currentPlayerService, movePositionCommand);
            PlayerRotateSignalAction playerRotateSignalAction = new PlayerRotateSignalAction(
                _currentPlayerService, setLookDirectionCommand);
            PlayerSpeedSignalAction playerSpeedSignalAction = new PlayerSpeedSignalAction(
                _currentPlayerService, setSpeedCommand);

            return new SignalController
            (
                new ISignalAction[]
                {
                    createPlayerSignalAction,
                    playerMoveSignalAction,
                    playerRotateSignalAction,
                    playerSpeedSignalAction
                }
            );
        }
    }
}
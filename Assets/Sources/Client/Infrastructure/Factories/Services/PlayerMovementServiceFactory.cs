using System;
using Sources.Client.Infrastructure.Services.MovementService;
using Sources.Client.InfrastructureInterfaces.Repositories;
using Sources.Client.InfrastructureInterfaces.Services.CurrentPlayers;
using Sources.Client.InfrastructureInterfaces.Services.InputServices;
using Sources.Client.InfrastructureInterfaces.Services.MovementServices;
using Sources.Client.UseCases.Common.Components.Positions.Queries;
using Sources.Client.UseCases.Common.Components.Speeds.Queries;
using Sources.Frameworks.SignalBuses.Interfaces;

namespace Sources.Client.Infrastructure.Factories.Services
{
    public class PlayerMovementServiceFactory
    {
        private readonly IInputService _inputService;
        private readonly ISignalBus _signalBus;
        private readonly ICurrentPlayerService _currentPlayerService;
        private readonly IEntityRepository _entityRepository;
        private readonly GetPositionQuery _getPositionQuery;
        private readonly GetSpeedQuery _getSpeedQuery;

        //TODO query хочется создавать в резовере как новые обьекты
        public PlayerMovementServiceFactory
        (
            IInputService inputService,
            ISignalBus signalBus,
            ICurrentPlayerService currentPlayerService,
            IEntityRepository entityRepository
        )
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));
            _currentPlayerService = currentPlayerService
                                    ?? throw new ArgumentNullException(nameof(currentPlayerService));
            _entityRepository = entityRepository ??
                                throw new ArgumentNullException(nameof(entityRepository));
            _getPositionQuery = new GetPositionQuery(entityRepository);
            _getSpeedQuery = new GetSpeedQuery(entityRepository);
        }

        public IPlayerMovementService Create()
        {
            return new PlayerMovementService
            (
                _inputService,
                _signalBus,
                _currentPlayerService,
                _getPositionQuery,
                _getSpeedQuery
            );
        }
    }
}
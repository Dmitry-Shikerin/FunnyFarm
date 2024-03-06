using System;
using Sources.Client.Controllers.Signals.Players;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Infrastructure.Services.CurrentPlayers;
using Sources.Client.UseCases.Queries.Players;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;
using Sources.Frameworks.SignalBuses.Interfaces;
using Sources.Frameworks.SignalBuses.Interfaces.Actions.Generic;

namespace Sources.Client.Controllers.Actions.Players
{
    public class CreatePlayerSignalAction : ISignalAction<CreatePlayerSignal>
    {
        private readonly ISignalBus _signalBus;
        private readonly IBindableViewBuilder<PlayerViewModel> _viewBuilder;
        private readonly CurrentPlayerService _currentPlayerService;
        private readonly CreateCurrentCharacterQuery _createCurrentCharacterQuery;

        public CreatePlayerSignalAction
        (
            ISignalBus signalBus,
            IBindableViewBuilder<PlayerViewModel> viewBuilder,
            CurrentPlayerService currentPlayerService,
            CreateCurrentCharacterQuery createCurrentCharacterQuery
        )
        {
            _signalBus = signalBus ?? throw new ArgumentNullException(nameof(signalBus));
            _viewBuilder = viewBuilder ?? throw new ArgumentNullException(nameof(viewBuilder));
            _currentPlayerService = currentPlayerService ??
                                    throw new ArgumentNullException(nameof(currentPlayerService));
            _createCurrentCharacterQuery = createCurrentCharacterQuery ??
                                           throw new ArgumentNullException(nameof(createCurrentCharacterQuery));
        }

        public void Handle(CreatePlayerSignal signal)
        {
            int playerId = _createCurrentCharacterQuery.Handle(signal.SpawnPosition);

            IBindableView view = _viewBuilder.Build(playerId,
                "Views/Players/", "PlayerView");

            _currentPlayerService.CharacterId = playerId;
        }
    }
}
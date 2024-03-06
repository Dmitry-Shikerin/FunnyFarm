using System;
using Sources.Client.Controllers.ViewModels;
using Sources.Client.Controllers.ViewModels.Components;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels
{
    public class PlayerViewModelFactory : IViewModelFactory<PlayerViewModel>
    {
        private readonly LookDirectionViewModelComponentFactory _lookDirectionViewModelComponentFactory;

        private readonly CharacterControllerMovementViewModelComponentFactory
            _characterControllerMovementViewModelComponentFactory;

        public PlayerViewModelFactory
        (
            LookDirectionViewModelComponentFactory lookDirectionViewModelComponentFactory,
            CharacterControllerMovementViewModelComponentFactory characterControllerMovementViewModelComponentFactory
        )
        {
            _lookDirectionViewModelComponentFactory =
                lookDirectionViewModelComponentFactory
                ?? throw new ArgumentNullException(nameof(lookDirectionViewModelComponentFactory));
            _characterControllerMovementViewModelComponentFactory =
                characterControllerMovementViewModelComponentFactory
                ?? throw new ArgumentNullException(nameof(characterControllerMovementViewModelComponentFactory));
        }

        public IViewModel Create(int id)
        {
            return new PlayerViewModel
            (
                new IViewModelComponent[]
                {
                    _lookDirectionViewModelComponentFactory.Create(id),
                    _characterControllerMovementViewModelComponentFactory.Create(id)
                }
            );
        }
    }
}
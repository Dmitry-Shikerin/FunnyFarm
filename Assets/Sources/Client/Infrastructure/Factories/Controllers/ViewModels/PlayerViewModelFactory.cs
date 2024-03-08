using System;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Common;
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
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly AnimationSpeedViewModelComponentFactory _animationSpeedViewModelComponentFactory;

        public PlayerViewModelFactory
        (
            LookDirectionViewModelComponentFactory lookDirectionViewModelComponentFactory,
            CharacterControllerMovementViewModelComponentFactory characterControllerMovementViewModelComponentFactory,
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            AnimationSpeedViewModelComponentFactory animationSpeedViewModelComponentFactory
        )
        {
            _lookDirectionViewModelComponentFactory =
                lookDirectionViewModelComponentFactory
                ?? throw new ArgumentNullException(nameof(lookDirectionViewModelComponentFactory));
            _characterControllerMovementViewModelComponentFactory =
                characterControllerMovementViewModelComponentFactory
                ?? throw new ArgumentNullException(nameof(characterControllerMovementViewModelComponentFactory));
            _visibilityViewModelComponentFactory = 
                visibilityViewModelComponentFactory
                ?? throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _animationSpeedViewModelComponentFactory = 
                animationSpeedViewModelComponentFactory 
                ?? throw new ArgumentNullException(nameof(animationSpeedViewModelComponentFactory));
        }

        public IViewModel Create(int id)
        {
            return new PlayerViewModel
            (
                new IViewModelComponent[]
                {
                    _lookDirectionViewModelComponentFactory.Create(id),
                    _characterControllerMovementViewModelComponentFactory.Create(id),
                    _visibilityViewModelComponentFactory.Create(id),
                    _animationSpeedViewModelComponentFactory.Create(id),
                }
            );
        }
    }
}
using System;
using Sources.Client.Controllers.ViewModels.Uis.GameplayHud.Forms;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Common;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Uis.Gameplay;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Uis.Gameplay
{
    public class PauseFormViewModelFactory : IViewModelFactory<PauseFormViewModel>
    {
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;
        private readonly ShowHudFormViewModelComponentFactory _showHudFormViewModelComponentFactory;

        public PauseFormViewModelFactory
        (
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory,
            ShowHudFormViewModelComponentFactory showHudFormViewModelComponentFactory
        )
        {
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory ??
                throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
            _showHudFormViewModelComponentFactory =
                showHudFormViewModelComponentFactory ?? 
                throw new ArgumentNullException(nameof(showHudFormViewModelComponentFactory));
        }

        public IViewModel Create(int id)
        {
            return new PauseFormViewModel
            (
                new IViewModelComponent[]
                {
                    _visibilityViewModelComponentFactory.Create(id),
                    _showHudFormViewModelComponentFactory.Create()
                }
            );
        }
    }
}
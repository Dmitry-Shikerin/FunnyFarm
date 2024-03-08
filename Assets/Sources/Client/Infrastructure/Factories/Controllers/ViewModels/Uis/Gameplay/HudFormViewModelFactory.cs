using System;
using Sources.Client.Controllers.ViewModels.Components;
using Sources.Client.Controllers.ViewModels.Uis.GameplayHud.Forms;
using Sources.Client.Domain.Ui.Forms;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Common;
using Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Uis.Gameplay;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Uis.Gameplay
{
    public class HudFormViewModelFactory : IViewModelFactory<HudFormViewModel>
    {
        private readonly ShowPauseFormViewModelComponentFactory _showPauseFormViewModelComponentFactory;
        private readonly VisibilityViewModelComponentFactory _visibilityViewModelComponentFactory;

        public HudFormViewModelFactory
        (
            ShowPauseFormViewModelComponentFactory showPauseFormViewModelComponentFactory,
            VisibilityViewModelComponentFactory visibilityViewModelComponentFactory
        )
        {
            _showPauseFormViewModelComponentFactory =
                showPauseFormViewModelComponentFactory
                ?? throw new ArgumentNullException(nameof(showPauseFormViewModelComponentFactory));
            _visibilityViewModelComponentFactory =
                visibilityViewModelComponentFactory 
                ?? throw new ArgumentNullException(nameof(visibilityViewModelComponentFactory));
        }

        //TODO указал покашто паузу
        //TODO добавить висибилити компонент
        public IViewModel Create(int id)
        {
            return new HudFormViewModel
                (
                    new IViewModelComponent[]
                    {
                        _showPauseFormViewModelComponentFactory.Create(),
                        _visibilityViewModelComponentFactory.Create(id)
                    }
                );
        }
    }
}
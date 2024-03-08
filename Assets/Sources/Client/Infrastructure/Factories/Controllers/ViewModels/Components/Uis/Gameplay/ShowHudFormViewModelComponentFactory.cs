using System;
using Sources.Client.Controllers.ViewModels.Components.Ui.Gameplay;
using Sources.Client.InfrastructureInterfaces.Services.Providers;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Uis.Gameplay
{
    public class ShowHudFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowHudFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowHudFormViewModelComponent Create()
        {
            return new ShowHudFormViewModelComponent(_formService);
        }
    }
}
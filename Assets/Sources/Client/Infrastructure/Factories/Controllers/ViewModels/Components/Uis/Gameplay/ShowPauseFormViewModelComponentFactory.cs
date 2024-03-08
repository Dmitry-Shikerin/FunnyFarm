using System;
using Sources.Client.Controllers.ViewModels.Components.Ui.Gameplay;
using Sources.Client.Domain.Ui.Forms;
using Sources.Client.InfrastructureInterfaces.Services.Providers;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels.Components.Uis.Gameplay
{
    public class ShowPauseFormViewModelComponentFactory
    {
        private readonly IFormService _formService;

        public ShowPauseFormViewModelComponentFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public ShowPauseFormViewModelComponent Create()
        {
            return new ShowPauseFormViewModelComponent(_formService);
        }
    }
}
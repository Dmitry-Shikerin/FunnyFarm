using System;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Services.Providers;
using Sources.Client.PresentationsInterfaces.Binds.Buttons;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.Domain.Attributes;
using UnityEngine;

namespace Sources.Client.Controllers.ViewModels.Components.Ui.Gameplay
{
    public class ShowPauseFormViewModelComponent : IViewModelComponent
    {
        private readonly IFormService _formService;

        public ShowPauseFormViewModelComponent(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }

        //TODO указать здесь имя обьекта на котором весит кнопка
        //TODO не пускаю все это дело через шину
        [MethodBinding(typeof(IButtonClickMethodBind))]
        private void OnClick(Vector3 position)
        {
            _formService.Show<PauseForm>();
        }
    }
}
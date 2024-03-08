using System;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Services.Providers;
using Sources.Client.PresentationsInterfaces.Binds.Buttons;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;
using Sources.Frameworks.MVVM.Domain.Attributes;
using UnityEngine;

namespace Sources.Client.Controllers.ViewModels.Components.Ui.Gameplay
{
    public class ShowHudFormViewModelComponent : IViewModelComponent
    {
        private readonly IFormService _formService;

        public ShowHudFormViewModelComponent(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
        
        [MethodBinding(typeof(IButtonClickMethodBind))]
        private void OnClick(Vector3 position)
        {
            _formService.Show<HudForm>();
        }
    }
}
using Sources.Frameworks.MVVM.Controllers;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;

namespace Sources.Client.Controllers.ViewModels.Uis.GameplayHud.Forms
{
    public class HudFormViewModel : ViewModelBase
    {
        public HudFormViewModel(IViewModelComponent[] components) : base(components)
        {
        }

        protected override void OnEnable()
        {
        }

        protected override void OnDisable()
        {
        }
    }
}
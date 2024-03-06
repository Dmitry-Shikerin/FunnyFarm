using Sources.Frameworks.MVVM.Controllers;
using Sources.Frameworks.MVVM.ControllersInterfaces.Components;

namespace Sources.Client.Controllers.ViewModels.Players
{
    public class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel(IViewModelComponent[] components) : base(components)
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
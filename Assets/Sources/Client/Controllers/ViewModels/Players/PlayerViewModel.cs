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
            throw new System.NotImplementedException();
        }

        protected override void OnDisable()
        {
            throw new System.NotImplementedException();
        }
    }
}
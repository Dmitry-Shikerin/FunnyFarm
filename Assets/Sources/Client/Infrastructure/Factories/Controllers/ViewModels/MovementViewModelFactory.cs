using Sources.Client.Controllers.ViewModels;
using Sources.Client.Controllers.ViewModels.Players;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders;

namespace Sources.Client.Infrastructure.Factories.Controllers.ViewModels
{
    //TODO это отдельная вьюмодель или компонент?
    public class MovementViewModelFactory : IViewModelFactory<PlayerViewModel>
    {
        public IViewModel Create(int id)
        {
            return null;
        }
    }
}
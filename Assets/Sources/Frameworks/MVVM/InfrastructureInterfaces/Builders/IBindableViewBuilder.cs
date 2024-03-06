using Sources.Frameworks.MVVM.ControllersInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders
{
    public interface IBindableViewBuilder<TViewModel> where TViewModel : IViewModel
    {
        //TODO сделать такойже класс только с дженериком модели и без энтити
        IBindableView Build(int entityId, string prefabName, IBindableView parent = null);
    }
}
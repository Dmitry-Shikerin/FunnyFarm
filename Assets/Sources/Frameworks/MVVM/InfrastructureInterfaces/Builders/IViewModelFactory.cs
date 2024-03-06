using Sources.Frameworks.MVVM.ControllersInterfaces;

namespace Sources.Frameworks.MVVM.InfrastructureInterfaces.Builders
{
    //TODO навешивается на каждую конкретную фабрику
    public interface IViewModelFactory<TViewModel> where TViewModel : IViewModel
    {
        //TODO сделать такуюже только без энтити
        IViewModel Create(int id);
    }
}
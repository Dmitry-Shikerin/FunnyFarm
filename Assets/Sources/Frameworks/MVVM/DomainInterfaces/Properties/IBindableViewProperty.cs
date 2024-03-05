using Sources.Frameworks.MVVM.DomainInterfaces.Services.Factories;

namespace Sources.Frameworks.MVVM.DomainInterfaces.Properties
{
    public interface IBindableViewProperty
    {
        //TODO почему здесь обджект?
        object OnBind(IBindablePropertyFactory factory);
    }
}
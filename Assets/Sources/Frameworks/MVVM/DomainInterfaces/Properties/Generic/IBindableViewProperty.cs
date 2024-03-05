using Sources.Frameworks.MVVM.DomainInterfaces.Services.Factories;

namespace Sources.Frameworks.MVVM.DomainInterfaces.Properties.Generic
{
    public interface IBindableViewProperty<T> : IBindableViewProperty
    {
        IBindableProperty<T> GetBinding(IBindablePropertyFactory factory);

        object IBindableViewProperty.OnBind(IBindablePropertyFactory factory) => 
            GetBinding(factory);
    }
}
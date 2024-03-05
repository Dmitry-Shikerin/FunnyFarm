using Sources.Frameworks.MVVM.DomainInterfaces.Properties;

namespace Sources.Frameworks.MVVM.DomainInterfaces.Services.Factories
{
    public interface IBindablePropertyFactory
    {
        IBindableProperty<T> Create<T>(object target, string propertyName);
    }
}
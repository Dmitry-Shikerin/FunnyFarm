using System.Reflection;
using Sources.Frameworks.MVVM.Domain.Properties;
using Sources.Frameworks.MVVM.DomainInterfaces.Properties;
using Sources.Frameworks.MVVM.DomainInterfaces.Services.Factories;

namespace Sources.Frameworks.MVVM.DomainServices.Factories
{
    public class BindablePropertyFactory : IBindablePropertyFactory
    {
        private static readonly BindingFlags s_bindingFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        public IBindableProperty<T> Create<T>(object target, string propertyName) => 
            new BindableProperty<T>(target, target.GetType().GetProperty(propertyName, s_bindingFlags));
    }
}
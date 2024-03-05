using Sources.Frameworks.MVVM.DomainInterfaces.Properties;
using Sources.Frameworks.MVVM.DomainInterfaces.Properties.Generic;
using Sources.Frameworks.MVVM.DomainInterfaces.Services.Factories;
using UnityEngine;

namespace Sources.Frameworks.MVVM.Domain.Properties
{
    public abstract class BindableViewProperty<T> : MonoBehaviour, IBindableViewProperty<T>
    {
        //TODO для чеего это поле?
        private IBindableProperty<T> _property;
        
        public abstract T BindableProperty { get; set; }
        
        public IBindableProperty<T> GetBinding(IBindablePropertyFactory factory) => 
            factory.Create<T>(this, nameof(BindableProperty));
    }
}
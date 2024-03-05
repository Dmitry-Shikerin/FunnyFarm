using System;
using Unity.VisualScripting;

namespace Sources.Frameworks.MVVM.DomainInterfaces.Properties
{
    public interface IBindableProperty<T> : IDisposable
    {
        public event Action Changed;
        
        public T Value { get; set; }
    }
}
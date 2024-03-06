using System.Reflection;
using Sources.Frameworks.MVVM.DomainInterfaces.Methods;

namespace Sources.Frameworks.MVVM.Domain.Methods
{
    public class BindableMethod<T> : IBindableMethod<T>
    {
        private readonly object _target;
        private readonly MethodInfo _methodInfo;

        public BindableMethod(object target, MethodInfo methodInfo)
        {
            _target = target;
            _methodInfo = methodInfo;
        }

        //TODO что здесь происходит?
        public void Invoke(params object[] args) => 
            _methodInfo?.Invoke(_target, args);
    }
}
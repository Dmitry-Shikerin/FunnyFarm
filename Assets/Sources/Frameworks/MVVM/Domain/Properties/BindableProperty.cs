using System;
using System.Collections.Generic;
using System.Reflection;
using Sources.Frameworks.MVVM.DomainInterfaces.Properties;

namespace Sources.Frameworks.MVVM.Domain.Properties
{
    public class BindableProperty<T> : IBindableProperty<T>
    {
        //TODO почему здесь обжект?
        //TOdo что такое пропертиинфо?
        //TODO что в целом происходит в этом классе?
        private readonly object _target;
        private readonly PropertyInfo _propertyInfo;
        private readonly List<Action> _actions = new List<Action>();

        public BindableProperty(object target, PropertyInfo propertyInfo)
        {
            _target = target;
            _propertyInfo = propertyInfo;
        }

        //TODO Для чего мы их сохраняем?
        public event Action Changed
        {
            add => _actions.Add(value);
            remove => _actions.Remove(value);
        }
        
        public T Value
        {
            get => (T)_propertyInfo.GetValue(_target);
            set
            {
                _propertyInfo.SetValue(_target, value);
                InvokeChanged();
            }
        }

        public void Dispose() => 
            _actions.Clear();

        //TODO получилолсь через линку
        private void InvokeChanged() => 
            _actions.ForEach(action => action.Invoke());
    }
}
using System;
using System.Reflection;

namespace Sources.Client.Infrastructure.Bindings
{
    public class ObservableField<T>
    {
        private readonly object _target;
        private readonly FieldInfo _fieldInfo;

        public ObservableField(object target, FieldInfo fieldInfo)
        {
            _target = target;
            _fieldInfo = fieldInfo;
        }

        public event Action Changed;
        
        public T Value
        {
            get => (T)_fieldInfo.GetValue(_target);
            set
            {
                _fieldInfo.SetValue(_target, value);
                
                Changed?.Invoke();
            }
        }
    }
}
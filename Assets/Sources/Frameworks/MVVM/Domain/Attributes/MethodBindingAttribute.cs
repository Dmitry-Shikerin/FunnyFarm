using System;

namespace Sources.Frameworks.MVVM.Domain.Attributes
{
    public class MethodBindingAttribute : Attribute
    {
        public MethodBindingAttribute(Type componentType, string componentName = null)
        {
            ComponentType = componentType;
            ComponentName = componentName;
        }

        public Type ComponentType { get; }
        public string ComponentName { get; }
    }
}
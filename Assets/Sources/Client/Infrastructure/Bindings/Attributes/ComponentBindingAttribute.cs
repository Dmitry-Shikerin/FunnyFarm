using System;

namespace Sources.Client.Infrastructure.Bindings.Attributes
{
    public class ComponentBindingAttribute : Attribute
    {
        public ComponentBindingAttribute(Type componentType)
        {
            ComponentType = componentType;
        }

        public Type ComponentType { get; }
    }
}
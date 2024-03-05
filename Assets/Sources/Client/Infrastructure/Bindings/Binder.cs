using System.Reflection;
using Sources.Client.Infrastructure.Bindings.Attributes;
using Sources.Client.Presentations.Views;
using Sources.Frameworks.MVVM.ControllersInterfaces;
using UnityEngine;

namespace Sources.Client.Infrastructure.Bindings
{
    public class Binder
    {
        private static readonly BindingFlags s_fieldBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        
        public void Bind(View view, IViewModel viewModel)
        {
            FieldInfo[] fields = viewModel.GetType().GetFields();

            foreach (FieldInfo fieldInfo in fields)
            {
                object[] attributeFields = fieldInfo.GetCustomAttributes(true);
                    
                foreach (object attribute in attributeFields)
                {
                    if (attribute is ComponentBindingAttribute bindingAttribute)
                    {
                        Component component = view.GetComponent(bindingAttribute.ComponentType);
                        
                        fieldInfo.SetValue(viewModel, component.transform.position);
                    }
                }
                
            }
        }

        public void Unbind(View view, IViewModel viewModel)
        {
        }
    }
}
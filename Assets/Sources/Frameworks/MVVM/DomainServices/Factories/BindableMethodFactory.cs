using System;
using System.Linq;
using System.Reflection;
using Sources.Frameworks.MVVM.Domain.Methods;
using Sources.Frameworks.MVVM.DomainInterfaces.Services.Factories;

namespace Sources.Frameworks.MVVM.DomainServices.Factories
{
    public class BindableMethodFactory : IBindableMethodFactory
    {
        public object Create(object viewModel, MethodInfo methodInfo)
        {
            //TODO почему можем не указывать дженерик
            //TODO потомучто это маркер?
            Type actionGenericType = typeof(BindableMethod<>);

            Type[] parameterTypes = methodInfo
                .GetParameters()
                .Select(info => info.ParameterType)
                .ToArray();

            Type actionType = actionGenericType.MakeGenericType(parameterTypes);

            //TODO что такое активатор
            //TODO что за запись в скобках
            return Activator.CreateInstance(actionType, new object[] { viewModel, methodInfo });
        }
    }
}
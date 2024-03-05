using System.Reflection;

namespace Sources.Frameworks.MVVM.DomainInterfaces.Services.Factories
{
    //Todo что такое BindableMethod?
    public interface IBindableMethodFactory
    {
        //Todo что здесь создается?
        object Create(object viewModel, MethodInfo methodInfo);
    }
}
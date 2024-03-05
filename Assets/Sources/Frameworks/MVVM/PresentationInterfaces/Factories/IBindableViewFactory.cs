using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.PresentationInterfaces.Factories
{
    public interface IBindableViewFactory
    {
        IBindableView Create(string viewPath, string name, IBindableView parent = null);
    }
}